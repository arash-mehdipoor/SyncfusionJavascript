using Microsoft.AspNetCore.Mvc.ModelBinding;
using Request.Body.Peeker;
using Syncfusion.EJ2.Base;

namespace SyncfusionJavascript.Models;

public class CustomModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

        var modelType = bindingContext.ModelType;
        var rawBody = bindingContext.HttpContext.Request.PeekBodyAsync().GetAwaiter().GetResult();
        var body = bindingContext.HttpContext.Request.PeekBody<DataManagerRequest>();

        dynamic created = Activator.CreateInstance(modelType);

        MapWhereFilterToQueryProperties(body, created, modelType);
        MapToPaginationProperty(body, created, modelType);

        bindingContext.Result = ModelBindingResult.Success(created);

        return Task.CompletedTask;
    }

    private void MapToPaginationProperty(DataManagerRequest body, dynamic created, Type modelType)
    {
        var calcPageNumber = (body.Skip / body.Take) + 1;
        _ = modelType.GetProperty("PageSize") is not null ? created.PageSize = body.Take : null;
        _ = modelType.GetProperty("PageNumber") is not null ? created.PageNumber = calcPageNumber : null;
        _ = modelType.GetProperty("SortAscending") is not null ? created.SortAscending = true : null;
        _ = modelType.GetProperty("SortBy") is not null ? created.SortBy = body.Sorted?.FirstOrDefault().Name ?? "Id" : null;
    }


    private static void MapWhereFilterToQueryProperties(DataManagerRequest body, dynamic created, Type? type)
    {
        foreach (var whereFilter in body.Where ?? Enumerable.Empty<WhereFilter>())
        {
            foreach (var prop in type.GetProperties())
            {
                if (prop.Name.ToLower() == whereFilter.Field.ToLower())
                {
                    if (whereFilter.value is Int64)
                    {
                        var parsInt = int.Parse(whereFilter.value.ToString());
                        prop.SetValue(created, parsInt, null);
                    }
                    else
                    {
                        prop.SetValue(created, whereFilter.value, null);
                    }
                }
            }

        }
    }
}

public class CustomModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        return new CustomModelBinder();
    }
}
