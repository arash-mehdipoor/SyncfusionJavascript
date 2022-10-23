using Microsoft.AspNetCore.Mvc.ModelBinding;
using Request.Body.Peeker;
using Syncfusion.EJ2.Base;
using System.Linq;
using System.Reflection;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace SyncfusionJavascript.Models;

public class CustomModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {

        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelType = bindingContext.ModelType;
        var rawBody = bindingContext.HttpContext.Request.PeekBodyAsync().GetAwaiter().GetResult();
        var body = bindingContext.HttpContext.Request.PeekBody<DataManagerRequest>();


        dynamic created = Activator.CreateInstance(modelType);


        var props = modelType.GetProperties().ToList();

        foreach (var whereFilter in body.Where ?? Enumerable.Empty<WhereFilter>()) 
        {
            foreach (var prop in props)
            {
                if (prop.Name.ToLower() == whereFilter.Field.ToLower())
                {
                    prop.SetValue(created, whereFilter.Field, null);
                }
            }

        }



        var pageNumberCacl = (body.Skip / body.Take) + 1;

        _ = modelType.GetProperty("PageSize") is not null ? created.PageSize = body.Take : null;
        _ = modelType.GetProperty("PageNumber") is not null ? created.PageNumber = pageNumberCacl : null;
        _ = modelType.GetProperty("SortAscending") is not null ? created.SortAscending = true : null;
        _ = modelType.GetProperty("SortBy") is not null ? created.SortBy = body.Sorted?.FirstOrDefault().Name ?? "Id" : null;

        bindingContext.Result = ModelBindingResult.Success(created);

        return Task.CompletedTask;
    }



}

public class CustomModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        return new CustomModelBinder();
    }
}
