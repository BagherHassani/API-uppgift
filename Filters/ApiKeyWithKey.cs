using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _02_API.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class _02_API_withKey : Attribute, IAsyncActionFilter
    {
       
        
        
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var apiKey = configuration.GetValue<string>("usKey");

                if (!context.HttpContext.Request.Headers.TryGetValue("code", out var providedCode))
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
