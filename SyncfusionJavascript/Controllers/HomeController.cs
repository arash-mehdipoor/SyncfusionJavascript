using Microsoft.AspNetCore.Mvc;
using Syncfusion.Data;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace SyncfusionJavascript.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly SyncfusionDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, SyncfusionDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult SeedData()
        {

            List<OrderDetail> ordersDetails = new List<OrderDetail>();

            if (dbContext.OrderDetails.Count() == 0)
            {
                int code = 100;
                for (int i = 1; i < 100; i++)
                {
                    ordersDetails.Add(new OrderDetail()
                    {
                        FirstName = $"آرش {i}",
                        LastName = $"مهدی پور {i}",
                        Address = $"تهران,تهران {i}",
                        Age = 29,
                        Birthdate = DateTime.Now,
                        City = "تهران",
                        Status = i % code == 0 ? true : false,
                    });
                    code += 5;
                }
            }
            dbContext.OrderDetails.AddRange(ordersDetails);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(SyncfusionTable));
        }

        public IActionResult SyncfusionData([FromBody][ModelBinder(Name = "arash", BinderType = typeof(CustomModelBinder))] PageQuery<OrderDetail> request)
        {
            var DataSource = dbContext.OrderDetails.AsQueryable();
            DataOperations operation = new DataOperations();
            var count = DataSource.Count();



            if (request.SkipCount != default)
                DataSource = operation.PerformSkip(DataSource, request.SkipCount);
            if (request.PageSize != default)
                DataSource = operation.PerformTake(DataSource, request.PageSize);

            if (request.SortBy != null)
            {
                DataSource = operation.PerformSorting(DataSource, new List<SortedColumn>() { new SortedColumn() { Field = request.SortBy } });
            }


            //if (request.Search != null && request.Search.Count > 0)
            //{
            //    DataSource = operation.PerformSearching(DataSource, request.Search);
            //}


            //if (request.Where != null && request.Where.Count > 0)
            //{
            //    DataSource = operation.PerformFiltering(DataSource, request.Where, "or");
            //}




            var json = Json(new { result = DataSource, count = count });
            return json;
        }




        public IActionResult SyncfusionTable()
        {
            var data = dbContext.OrderDetails.ToList();
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        //public class QueryableOperation2
        //{
        //    private Type DataSourceType<T>(IQueryable<T> dataSource)
        //    {
        //        Type type = dataSource.GetElementType();
        //        if (type == null)
        //        {
        //            Type type2 = dataSource.GetType();
        //            type = ((!type2.FullName!.Contains("IncludableQueryable")) ? type2.GetElementType() : dataSource.GetObjectType());
        //        }

        //        return type;
        //    }

        //    public IQueryable<T> Execute<T>(IQueryable<T> dataSource, DataManagerRequest manager)
        //    {
        //        if (manager.Where != null && manager.Where.Count > 0)
        //        {
        //            dataSource = PerformFiltering(dataSource, manager.Where, string.Empty);
        //        }

        //        if (manager.Search != null && manager.Search.Count > 0)
        //        {
        //            dataSource = PerformSearching(dataSource, manager.Search);
        //        }

        //        if (manager.Sorted != null && manager.Sorted.Count > 0)
        //        {
        //            dataSource = PerformSorting(dataSource, manager.Sorted);
        //        }

        //        if (manager.Skip != 0)
        //        {
        //            dataSource = PerformSkip(dataSource, manager.Skip);
        //        }

        //        if (manager.Take != 0)
        //        {
        //            dataSource = PerformTake(dataSource, manager.Take);
        //        }

        //        return dataSource;
        //    }

        //    public IQueryable PerformGrouping<T>(IQueryable<T> dataSource, List<string> grouped)
        //    {
        //        string[] array = grouped.Cast<string>().ToArray();
        //        Type type = DataSourceType(dataSource);
        //        IQueryable queryable = null;
        //        return dataSource.GroupByMany(grouped).AsQueryable();
        //    }

        //    private Expression PerformComplexExpression(ParameterExpression param, string select)
        //    {
        //        Expression expression = param;
        //        string[] array = select.Split('.');
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            if (int.TryParse(array[i], out int _))
        //            {
        //                int num = Convert.ToInt16(array[i]);
        //                if (i + 1 <= array.Length - 1)
        //                {
        //                    expression = Expression.PropertyOrField(Expression.ArrayIndex(expression, Expression.Constant(num)), array[i + 1]);
        //                    i++;
        //                }
        //                else
        //                {
        //                    expression = Expression.ArrayIndex(expression, Expression.Constant(num));
        //                }
        //            }
        //            else
        //            {
        //                expression = Expression.PropertyOrField(expression, array[i]);
        //            }
        //        }

        //        return expression;
        //    }

        //    private IQueryable PerformComplexDataOperation<T>(IQueryable<T> dataSource, string select)
        //    {
        //        ParameterExpression param = Expression.Parameter(typeof(T), "a");
        //        Expression property = PerformComplexExpression(param, select);
        //        Type columnType = GetColumnType(dataSource, select, typeof(T));
        //        if (NullableHelperInternal.GetUnderlyingType(columnType) != null)
        //        {
        //            columnType = NullableHelperInternal.GetUnderlyingType(columnType);
        //            if (columnType.Name.ToLower().Equals("int32"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, int?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("uint32"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, uint?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("int64"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, long?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("uint64"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, ulong?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("int16"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, short?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("uint16"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, ushort?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("double"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, double?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("single") || columnType.Name.ToLower().Equals("float"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, float?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("char"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, char?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("boolean"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, bool?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("byte"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, byte?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("sbyte"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, sbyte?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            if (columnType.Name.ToLower().Equals("decimal"))
        //            {
        //                return dataSource.Select((T a, int i) => new
        //                {
        //                    a = a,
        //                    TempData = dataSource.Select(Expression.Lambda<Func<T, decimal?>>(property, new ParameterExpression[1]
        //                    {
        //                    param
        //                    })).ToList()[i]
        //                });
        //            }

        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, object>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("int32"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, int>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("uint32"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, uint>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("int64"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, long>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("uint64"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, ulong>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("int16"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, short>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("uint16"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, ushort>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("string"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, string>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("double"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, double>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("single") || columnType.Name.ToLower().Equals("float"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, float>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("char"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, char>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("bool"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, bool>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("byte"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, byte>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("sbyte"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, sbyte>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        if (columnType.Name.ToLower().Equals("decimal"))
        //        {
        //            return dataSource.Select((T a, int i) => new
        //            {
        //                a = a,
        //                TempData = dataSource.Select(Expression.Lambda<Func<T, decimal>>(property, new ParameterExpression[1]
        //                {
        //                param
        //                })).ToList()[i]
        //            });
        //        }

        //        return dataSource.Select((T a, int i) => new
        //        {
        //            a = a,
        //            TempData = dataSource.Select(Expression.Lambda<Func<T, object>>(property, new ParameterExpression[1]
        //            {
        //            param
        //            })).ToList()[i]
        //        });
        //    }

        //    internal IQueryable performComplexSorting<T>(IQueryable<T> dataSource, string sortedColumns, bool firstTime, SortOrder sort)
        //    {
        //        Type type = dataSource.GetType();
        //        if (!type.FullName!.Contains("System.Data.Entity.DbSet") && !type.FullName!.Contains("IncludableQueryable") && !type.FullName!.Contains("EntityQueryable"))
        //        {
        //            IQueryable source = PerformComplexDataOperation(dataSource, sortedColumns);
        //            Type objectType = source.GetObjectType();
        //            source = ((sort != SortOrder.Ascending) ? (firstTime ? source.OrderByDescending("TempData", objectType) : source.ThenByDescending("TempData", objectType)) : (firstTime ? source.OrderBy("TempData", objectType) : source.ThenBy("TempData", objectType)));
        //            return source.Select("a", objectType);
        //        }

        //        ParameterExpression parameterExpression = Expression.Parameter(typeof(T), string.Empty);
        //        Expression valueExpression = parameterExpression.GetValueExpression(sortedColumns, typeof(T));
        //        LambdaExpression lambdaExpression = Expression.Lambda(valueExpression, parameterExpression);
        //        string methodName = (!firstTime) ? ((sort == SortOrder.Ascending) ? "ThenBy" : "ThenByDescending") : ((sort == SortOrder.Ascending) ? "OrderBy" : "OrderByDescending");
        //        IQueryable queryable = dataSource;
        //        return queryable.Provider.CreateQuery(Expression.Call(typeof(Queryable), methodName, new Type[2]
        //        {
        //        queryable.ElementType,
        //        lambdaExpression.Body.Type
        //        }, queryable.Expression, Expression.Quote(lambdaExpression)));
        //    }

        //    public IQueryable<T> PerformSorting<T>(IQueryable<T> dataSource, List<SortedColumn> sortedColumns)
        //    {
        //        bool flag = true;
        //        Type objectType = dataSource.GetObjectType();
        //        foreach (SortedColumn sortedColumn in sortedColumns)
        //        {
        //            if (sortedColumn.Field.Contains('.'))
        //            {
        //                dataSource = performComplexSorting(dataSource, sortedColumn.Field, flag, sortedColumn.Direction).Cast<T>();
        //                flag = false;
        //            }
        //            else if (sortedColumn.Direction == SortOrder.Ascending)
        //            {
        //                if (flag)
        //                {
        //                    dataSource = OrderingHelper(dataSource, sortedColumn.Field, "OrderBy");
        //                    flag = false;
        //                }
        //                else
        //                {
        //                    dataSource = OrderingHelper(dataSource, sortedColumn.Field, "ThenBy");
        //                }
        //            }
        //            else if (flag)
        //            {
        //                dataSource = OrderingHelper(dataSource, sortedColumn.Field, "OrderByDescending");
        //                flag = false;
        //            }
        //            else
        //            {
        //                dataSource = OrderingHelper(dataSource, sortedColumn.Field, "ThenByDescending");
        //            }
        //        }

        //        return dataSource;
        //    }

        //    public IQueryable<T> PerformSorting<T>(IQueryable<T> dataSource, List<Sort> sortedColumns)
        //    {
        //        List<SortedColumn> list = new List<SortedColumn>();
        //        if (sortedColumns.Count > 1)
        //        {
        //            sortedColumns.Reverse();
        //        }

        //        foreach (Sort sortedColumn in sortedColumns)
        //        {
        //            SortOrder direction = (SortOrder)Enum.Parse(typeof(SortOrder), sortedColumn.Direction.ToString(), ignoreCase: true);
        //            list.Add(new SortedColumn
        //            {
        //                Direction = direction,
        //                Field = sortedColumn.Name
        //            });
        //        }

        //        dataSource = PerformSorting(dataSource, list);
        //        return dataSource;
        //    }

        //    private IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, string operation)
        //    {
        //        ParameterExpression parameterExpression = Expression.Parameter(typeof(T), string.Empty);
        //        MemberExpression memberExpression = Expression.PropertyOrField(parameterExpression, propertyName);
        //        LambdaExpression expression = Expression.Lambda(memberExpression, parameterExpression);
        //        MethodCallExpression expression2 = Expression.Call(typeof(Queryable), operation, new Type[2]
        //        {
        //        typeof(T),
        //        memberExpression.Type
        //        }, source.Expression, Expression.Quote(expression));
        //        return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(expression2);
        //    }

        //    public IQueryable<T> PerformSkip<T>(IQueryable<T> dataSource, int skip)
        //    {
        //        IQueryable<T> source = dataSource.AsQueryable();
        //        return source.Skip(skip);
        //    }

        //    public IQueryable<T> PerformTake<T>(IQueryable<T> dataSource, int take)
        //    {
        //        IQueryable<T> source = dataSource.AsQueryable();
        //        return source.Take(take);
        //    }

        //    private Type GetDataType<T>(IQueryable<T> dataSource, Type type, string field)
        //    {
        //        string[] array = field.Split('.');
        //        if (type.GetProperty(array[0]) == null)
        //        {
        //            type = dataSource.GetObjectType();
        //        }

        //        return type;
        //    }

        //    private Type GetColumnType<T>(IQueryable<T> dataSource, string filterString, Type type)
        //    {
        //        string[] array = filterString.Split('.');
        //        PropertyInfo propertyInfo = null;
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            if (int.TryParse(array[i], out int _))
        //            {
        //                type = type.GetElementType();
        //                continue;
        //            }

        //            propertyInfo = type.GetProperty(array[i]);
        //            type = propertyInfo.PropertyType;
        //        }

        //        return propertyInfo.PropertyType;
        //    }

        //    public IQueryable<T> PerformSearching<T>(IQueryable<T> dataSource, List<SearchFilter> searchFilter)
        //    {
        //        Type type = DataSourceType(dataSource);
        //        Type typeFromHandle = typeof(object);
        //        foreach (SearchFilter item in searchFilter)
        //        {
        //            ParameterExpression parameterExpression = type.Parameter();
        //            bool flag = true;
        //            Expression expression = null;
        //            foreach (string field in item.Fields)
        //            {
        //                type = GetDataType(dataSource, type, field);
        //                typeFromHandle = GetColumnType(dataSource, field, type);
        //                Expression valueExpression = parameterExpression.GetValueExpression(field, type);
        //                Type type2 = valueExpression.Type;
        //                bool flag2 = false;
        //                FilterType filterType;
        //                string constValue;
        //                if (type2.FullName == "System.Boolean")
        //                {
        //                    string text = "equals";
        //                    filterType = (FilterType)Enum.Parse(typeof(FilterType), text.ToString(), ignoreCase: true);
        //                    if (item.Key.ToLower().Equals("f") || item.Key.ToLower().Equals("fa") || item.Key.ToLower().Equals("fal") || item.Key.ToLower().Equals("fals") || item.Key.ToLower().Equals("false"))
        //                    {
        //                        constValue = "false";
        //                        flag2 = true;
        //                    }
        //                    else if (item.Key.ToLower().Equals("t") || item.Key.ToLower().Equals("tr") || item.Key.ToLower().Equals("tru") || item.Key.ToLower().Equals("true"))
        //                    {
        //                        constValue = "true";
        //                        flag2 = true;
        //                    }
        //                    else
        //                    {
        //                        constValue = item.Key;
        //                        flag2 = false;
        //                    }
        //                }
        //                else
        //                {
        //                    string text = (item.Operator == "equal") ? "equals" : ((item.Operator == "notequal") ? "notequals" : item.Operator);
        //                    constValue = item.Key;
        //                    filterType = (FilterType)Enum.Parse(typeof(FilterType), text.ToString(), ignoreCase: true);
        //                    flag2 = true;
        //                }

        //                if (flag2)
        //                {
        //                    if (flag)
        //                    {
        //                        expression = dataSource.Predicate(parameterExpression, field, constValue, filterType, FilterBehavior.StringTyped, isCaseSensitive: false, type);
        //                        flag = false;
        //                    }
        //                    else
        //                    {
        //                        expression = expression.OrPredicate(dataSource.Predicate(parameterExpression, field, constValue, filterType, FilterBehavior.StringTyped, isCaseSensitive: false, type));
        //                    }
        //                }
        //            }

        //            dataSource = dataSource.Where(Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[1]
        //            {
        //            parameterExpression
        //            }));
        //        }

        //        return dataSource;
        //    }

        //    public Expression PredicateBuilder<T>(IQueryable<T> dataSource, List<WhereFilter> whereFilter, string condition, ParameterExpression paramExpression, Type type)
        //    {
        //        Type typeFromHandle = typeof(object);
        //        Expression expression = null;
        //        foreach (WhereFilter item in whereFilter)
        //        {
        //            if (item.IsComplex)
        //            {
        //                expression = ((expression != null) ? ((!(condition == "or")) ? expression.AndAlsoPredicate(PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type)) : expression.OrElsePredicate(PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type))) : PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type));
        //                continue;
        //            }

        //            string text = (item.Operator == "equal") ? "equals" : ((item.Operator == "notequal") ? "notequals" : item.Operator);
        //            FilterType filterType = (FilterType)Enum.Parse(typeof(FilterType), text.ToString(), ignoreCase: true);
        //            type = GetDataType(dataSource, type, item.Field);
        //            typeFromHandle = GetColumnType(dataSource, item.Field, type);
        //            Type underlyingType = Nullable.GetUnderlyingType(typeFromHandle);
        //            if (underlyingType != null)
        //            {
        //                typeFromHandle = underlyingType;
        //            }

        //            object obj = item.value;
        //            if (obj != null)
        //            {
        //                if (typeFromHandle == typeof(Guid))
        //                {
        //                    obj = (Guid)TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromInvariantString(item.value.ToString());
        //                }
        //                else if (typeFromHandle.Name == "DateTime" && item.value.GetType() != typeof(DateTime))
        //                {
        //                    item.value = DateTimeOffset.Parse(item.value.ToString()).UtcDateTime;
        //                    obj = Convert.ChangeType(item.value, typeFromHandle);
        //                }
        //                else if (item.value.GetType().Name == typeFromHandle.Name)
        //                {
        //                    obj = Convert.ChangeType(item.value, typeFromHandle);
        //                }
        //            }

        //            expression = ((expression != null) ? ((!(condition == "or")) ? expression.AndPredicate(dataSource.Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type)) : expression.OrPredicate(dataSource.Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type))) : dataSource.Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type));
        //        }

        //        return expression;
        //    }

        //    public IQueryable<T> PerformFiltering<T>(IQueryable<T> dataSource, List<WhereFilter> whereFilter, string condition)
        //    {
        //        Type type = DataSourceType(dataSource);
        //        ParameterExpression parameterExpression = type.Parameter();
        //        dataSource = dataSource.Where(Expression.Lambda<Func<T, bool>>(PredicateBuilder(dataSource, whereFilter, condition, parameterExpression, type), new ParameterExpression[1]
        //        {
        //        parameterExpression
        //        }));
        //        return dataSource;
        //    }

        //    public IQueryable PerformSelect<T>(IQueryable<T> dataSource, List<string> select)
        //    {
        //        IEnumerable<string> properties = select.Where((string item) => item != null);
        //        Type type = dataSource.AsQueryable().GetObjectType();
        //        if (type == typeof(object))
        //        {
        //            IEnumerator<T> enumerator = dataSource.GetEnumerator();
        //            if (enumerator.MoveNext())
        //            {
        //                type = enumerator.Current.GetType();
        //            }
        //        }

        //        return dataSource.Select(properties, type);
        //    }
        //}


        //private EnumerableOperation enumerableOperation = new EnumerableOperation();

        //private QueryableOperation2 op = new QueryableOperation2();

        //public virtual IEnumerable<T> PerformFiltering<T>(IEnumerable<T> dataSource, List<WhereFilter> whereFilter, string condition)
        //{
        //    return op.PerformFiltering(dataSource.AsQueryable(), whereFilter, condition);
        //}

        //public IQueryable<T> PerformFiltering<T>(IQueryable<T> dataSource, List<WhereFilter> whereFilter, string condition)
        //{
        //    Type type = DataSourceType(dataSource);
        //    ParameterExpression parameterExpression = type.Parameter();
        //    dataSource = dataSource.Where(Expression.Lambda<Func<T, bool>>(PredicateBuilder(dataSource, whereFilter, condition, parameterExpression, type), new ParameterExpression[1]
        //    {
        //        parameterExpression
        //    }));
        //    return dataSource;
        //}
        //private Type DataSourceType<T>(IQueryable<T> dataSource)
        //{
        //    Type type = dataSource.GetElementType();
        //    if (type == null)
        //    {
        //        Type type2 = dataSource.GetType();
        //        type = ((!type2.FullName!.Contains("IncludableQueryable")) ? type2.GetElementType() : dataSource.GetObjectType());
        //    }

        //    return type;
        //}
        //private static Expression PredicateBuilder(IEnumerable dataSource, List<WhereFilter> whereFilter, string condition, ParameterExpression paramExpression, Type type)
        //{
        //    Type typeFromHandle = typeof(object);
        //    Expression expression = null;
        //    foreach (WhereFilter item in whereFilter)
        //    {
        //        if (item.IsComplex)
        //        {
        //            expression = ((expression != null) ? ((!(condition == "or")) ? expression.AndAlsoPredicate(PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type)) : expression.OrElsePredicate(PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type))) : PredicateBuilder(dataSource, item.predicates, item.Condition, paramExpression, type));
        //            continue;
        //        }

        //        string text = item.Operator;
        //        if (text == "equal")
        //        {
        //            text = "equals";
        //        }
        //        else if (text == "notequal")
        //        {
        //            text = "notequals";
        //        }

        //        FilterType filterType = (FilterType)Enum.Parse(typeof(FilterType), text.ToString(), ignoreCase: true);
        //        type = GetDataType(dataSource, type, item.Field);
        //        typeFromHandle = GetColumnType(dataSource, item.Field, type);
        //        Type underlyingType = Nullable.GetUnderlyingType(typeFromHandle);
        //        if (underlyingType != null)
        //        {
        //            typeFromHandle = underlyingType;
        //        }

        //        object obj = item.value;
        //        if (obj != null)
        //        {
        //            if (typeFromHandle == typeof(Guid))
        //            {
        //                obj = (Guid)TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromInvariantString(item.value.ToString());
        //            }
        //            else if (item.value.GetType().Name == typeFromHandle.Name)
        //            {
        //                if (typeFromHandle.Name == "DateTime")
        //                {
        //                    item.value = DateTimeOffset.Parse(item.value.ToString()).UtcDateTime;
        //                }

        //                obj = Convert.ChangeType(item.value, typeFromHandle);
        //            }
        //        }

        //        if (expression == null)
        //        {
        //            expression = dataSource.AsQueryable().Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type);
        //            continue;
        //        }

        //        if (typeFromHandle.Name == "String" && obj == null)
        //        {
        //            obj = "";
        //        }

        //        expression = ((!(condition == "or")) ? expression.AndPredicate(dataSource.AsQueryable().Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type)) : expression.OrPredicate(dataSource.AsQueryable().Predicate(paramExpression, item.Field, obj, filterType, FilterBehavior.StringTyped, !item.IgnoreCase, type)));
        //    }

        //    return expression;
        //}

        //public static Type GetDataType(IEnumerable dataSource, Type type, string field)
        //{
        //    string[] array = field.Split('.');
        //    if (type.GetProperty(array[0]) == null)
        //    {
        //        type = dataSource.AsQueryable().GetObjectType();
        //    }

        //    return type;
        //}

        //public static Type GetColumnType(IEnumerable dataSource, string filterString, Type type)
        //{
        //    string[] array = filterString.Split('.');
        //    PropertyInfo propertyInfo = null;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (int.TryParse(array[i], out var _))
        //        {
        //            type = type.GetProperties()[2].PropertyType;
        //            continue;
        //        }

        //        propertyInfo = type.GetProperty(array[i]);
        //        type = propertyInfo.PropertyType;
        //    }

        //    return propertyInfo.PropertyType;
        //}
        //public class DataOperations2
        //{
        //    private EnumerableOperation enumerableOperation = new EnumerableOperation();

        //    private QueryableOperation2 op = new QueryableOperation2();

        //    public virtual IEnumerable Execute(IEnumerable dataSource, DataManagerRequest manager)
        //    {
        //        return enumerableOperation.Execute(dataSource, manager);
        //    }

        //    public virtual IEnumerable PerformSorting(IEnumerable dataSource, List<SortedColumn> sortedColumns)
        //    {
        //        return enumerableOperation.PerformSorting(dataSource, sortedColumns);
        //    }

        //    public virtual IEnumerable PerformSorting(IEnumerable dataSource, List<Sort> sortedColumns)
        //    {
        //        return enumerableOperation.PerformSorting(dataSource, sortedColumns);
        //    }

        //    //public virtual IEnumerable PerformFiltering(IEnumerable dataSource, List<WhereFilter> whereFilter, string condition)
        //    //{
        //    //    return enumerableOperation.PerformFiltering(dataSource, whereFilter, condition);
        //    //}
        //    public IEnumerable PerformFiltering(IEnumerable dataSource, List<WhereFilter> whereFilter, string condition)
        //    {
        //        Type elementType = dataSource.GetElementType();
        //        if (elementType == null)
        //        {
        //            Type type = dataSource.GetType();
        //            elementType = type.GetElementType();
        //        }

        //        ParameterExpression paramExpression = elementType.Parameter();
        //        dataSource = dataSource.AsQueryable().Where(paramExpression, predicateExpression: PredicateBuilder(dataSource, whereFilter, condition, paramExpression, elementType));
        //        return dataSource;
        //    }

        //    public virtual IEnumerable PerformSelect(IEnumerable dataSource, List<string> select)
        //    {
        //        return enumerableOperation.PerformSelect(dataSource, select);
        //    }

        //    public virtual IEnumerable PerformSearching(IEnumerable dataSource, List<SearchFilter> searchFilter)
        //    {
        //        return enumerableOperation.PerformSearching(dataSource, searchFilter);
        //    }

        //    public virtual IEnumerable PerformSkip(IEnumerable dataSource, int skip)
        //    {
        //        return enumerableOperation.PerformSkip(dataSource, skip);
        //    }

        //    public virtual IEnumerable PerformTake(IEnumerable dataSource, int take)
        //    {
        //        return enumerableOperation.PerformTake(dataSource, take);
        //    }

        //    public virtual IEnumerable PerformGrouping(IEnumerable dataSource, List<string> grouped)
        //    {
        //        return enumerableOperation.PerformGrouping(dataSource, grouped);
        //    }

        //    public virtual IEnumerable PerformGrouping<T>(IEnumerable DataSource, DataManagerRequest dm)
        //    {
        //        if (!dm.IsLazyLoad)
        //        {
        //            return enumerableOperation.PerformGrouping<T>(DataSource, dm.Group, dm.Aggregates);
        //        }

        //        return enumerableOperation.PerformLazyLoadGrouping<T>(DataSource, dm);
        //    }

        //    public virtual IEnumerable<T> Execute<T>(IEnumerable<T> dataSource, DataManagerRequest manager)
        //    {
        //        return op.Execute(dataSource.AsQueryable(), manager);
        //    }

        //    public virtual IEnumerable<T> PerformSkip<T>(IEnumerable<T> dataSource, int skip)
        //    {
        //        return op.PerformSkip(dataSource.AsQueryable(), skip);
        //    }

        //    public virtual IEnumerable<T> PerformTake<T>(IEnumerable<T> dataSource, int take)
        //    {
        //        return op.PerformTake(dataSource.AsQueryable(), take);
        //    }

        //    public virtual IEnumerable PerformGrouping<T>(IEnumerable<T> dataSource, List<string> grouped)
        //    {
        //        return op.PerformGrouping(dataSource.AsQueryable(), grouped);
        //    }

        //    public virtual IEnumerable<T> PerformSorting<T>(IEnumerable<T> dataSource, List<SortedColumn> sortedColumns)
        //    {
        //        return op.PerformSorting(dataSource.AsQueryable(), sortedColumns);
        //    }

        //    public virtual IEnumerable<T> PerformSorting<T>(IEnumerable<T> dataSource, List<Sort> sortedColumns)
        //    {
        //        return op.PerformSorting(dataSource.AsQueryable(), sortedColumns);
        //    }

        //    public virtual IEnumerable PerformSelect<T>(IEnumerable<T> dataSource, List<string> select)
        //    {
        //        return op.PerformSelect(dataSource.AsQueryable(), select);
        //    }

        //    public virtual IEnumerable<T> PerformSearching<T>(IEnumerable<T> dataSource, List<SearchFilter> searchFilter)
        //    {
        //        return op.PerformSearching(dataSource.AsQueryable(), searchFilter);
        //    }

        //    public virtual IEnumerable<T> PerformFiltering<T>(IEnumerable<T> dataSource, List<WhereFilter> whereFilter, string condition)
        //    {
        //        return op.PerformFiltering(dataSource.AsQueryable(), whereFilter, condition);
        //    }

        //    public virtual IQueryable<T> Execute<T>(IQueryable<T> dataSource, DataManagerRequest manager)
        //    {
        //        return op.Execute(dataSource, manager);
        //    }

        //    public virtual IQueryable PerformGrouping<T>(IQueryable<T> dataSource, List<string> grouped)
        //    {
        //        return op.PerformGrouping(dataSource, grouped);
        //    }

        //    public virtual IQueryable<T> PerformSorting<T>(IQueryable<T> dataSource, List<SortedColumn> sortedColumns)
        //    {
        //        return op.PerformSorting(dataSource, sortedColumns);
        //    }

        //    public virtual IQueryable<T> PerformSorting<T>(IQueryable<T> dataSource, List<Sort> sortedColumns)
        //    {
        //        return op.PerformSorting(dataSource, sortedColumns);
        //    }

        //    public virtual IQueryable<T> PerformSkip<T>(IQueryable<T> dataSource, int skip)
        //    {
        //        return op.PerformSkip(dataSource, skip);
        //    }

        //    public virtual IQueryable<T> PerformTake<T>(IQueryable<T> dataSource, int take)
        //    {
        //        return op.PerformTake(dataSource, take);
        //    }

        //    public virtual IQueryable<T> PerformSearching<T>(IQueryable<T> dataSource, List<SearchFilter> searchFilter)
        //    {
        //        return op.PerformSearching(dataSource, searchFilter);
        //    }

        //    public virtual IQueryable<T> PerformFiltering<T>(IQueryable<T> dataSource, List<WhereFilter> whereFilter, string condition)
        //    {
        //        return op.PerformFiltering(dataSource, whereFilter, condition);
        //    }

        //    public virtual IQueryable PerformSelect<T>(IQueryable<T> dataSource, List<string> select)
        //    {
        //        return op.PerformSelect(dataSource, select);
        //    }
        //}

    }
}
