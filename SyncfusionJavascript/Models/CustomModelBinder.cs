using Microsoft.AspNetCore.Mvc.ModelBinding;
using Request.Body.Peeker;
using Syncfusion.EJ2.Base;

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
        created.PageSize = body.Take;
        created.PageNumber = 1;
        created.SortAscending = true;
        created.SortBy = body.Sorted?.FirstOrDefault().Name ?? "Id";

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
