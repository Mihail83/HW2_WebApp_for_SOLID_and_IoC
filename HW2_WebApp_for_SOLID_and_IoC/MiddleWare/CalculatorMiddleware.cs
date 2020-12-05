using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW2_WebApp_for_SOLID_and_IoC.Services;

namespace HW2_WebApp_for_SOLID_and_IoC.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CalculatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IChooseOperationForCalculator _chooseOperationForCalculator;
        private readonly IPlus _plus;
        private readonly IMinus _minus;
        private readonly IMultiply _multiply;
        private readonly IDivide _divide;
        Func<double, double, double> operation; 


        public CalculatorMiddleware(RequestDelegate next, 
                                    IChooseOperationForCalculator chooseOperationForCalculator,
                                    IPlus plus,
                                    IMinus minus,
                                    IMultiply multiply,
                                    IDivide divide)
        {
            _next = next;
            _chooseOperationForCalculator = chooseOperationForCalculator;
            _plus = plus;
            _minus = minus;
            _multiply = multiply;
            _divide = divide;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            operation = _chooseOperationForCalculator.Choose(httpContext.Request.Query["op"], _plus, _minus, _multiply, _divide);
            var firstNumber = double.Parse(httpContext.Request.Query["fn"]);
            var secondNumber = double.Parse(httpContext.Request.Query["sn"]);

            await httpContext.Response.WriteAsync(operation(firstNumber,secondNumber).ToString());


            //await httpContext.Response.WriteAsync("error CalculatorMiddleware ");
             //await _next.Invoke(httpContext);
        }
    }

    //Extension method used to add the middleware to the HTTP request pipeline.
    //public static class CalculatorMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseCalculatorMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<CalculatorMiddleware>();
    //    }
    //}
}
