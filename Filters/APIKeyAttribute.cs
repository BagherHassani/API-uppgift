using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _02_API.Filters.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class APIKeyAttribute : Attribute, IAsyncActionFilter
    {
       
        
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var apiKey = configuration.GetValue<string>("ApiKey");

            

                if (!context.HttpContext.Request.Query.TryGetValue("code", out var providedCode))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                if (!apiKey.Equals(providedCode))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                await next();
            }
    }
}
