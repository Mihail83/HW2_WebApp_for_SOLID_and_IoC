using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW2_WebApp_for_SOLID_and_IoC.Services;

namespace HW2_WebApp_for_SOLID_and_IoC.MiddleWare
{    
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IValidationForCalculator _validator;
        public ValidationMiddleware(RequestDelegate next, IValidationForCalculator validator)
        {
            _next = next;
            _validator = validator;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string[] keyList = { httpContext.Request.Query["fn"],
                                 httpContext.Request.Query["sn"], 
                                 httpContext.Request.Query["op"] };

            if (_validator.OkForCalculator(keyList))
            {
                await _next(httpContext);
            }
            else
            {
                await httpContext.Response.WriteAsync("invalid key or not number");
            }            
        }
    }    
    public static class ValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationMiddleware(this IApplicationBuilder builder, IValidationForCalculator validator)
        {
            return builder.UseMiddleware<ValidationMiddleware>(validator);
        }
    }
}
