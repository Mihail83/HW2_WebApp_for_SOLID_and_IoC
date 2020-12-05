using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW2_WebApp_for_SOLID_and_IoC.MiddleWare;

using HW2_WebApp_for_SOLID_and_IoC.Services;

namespace HW2_WebApp_for_SOLID_and_IoC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IValidationForCalculator,CommonValidationForCalculator>();
            services.AddSingleton<IChooseOperationForCalculator, ChooseOperationForCalculator>();
            if (true)
            {
                services.AddSingleton<IPlus, Class_Plus>();
                services.AddSingleton<IMinus, Class_Minus>();
                services.AddSingleton<IMultiply, Class_Multiply>();
                services.AddSingleton<IDivide, Class_Divide>();
            }
            else
            {
                services.AddTransient<IPlus, AnotherPlus>();
                services.AddTransient<IMinus, AnotherMinus>();
                services.AddTransient<IMultiply, AnotherMultiply>();
                services.AddTransient<IDivide, AnotherDivide>();
            }            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           

            app.UseRouting();
            app.Map("/index", Index);
            app.Map("/about", About);
            //app.Map("/calc", Calc);
            app.Map("/calc", calc =>calc.MapWhen(context =>
                            context.Request.Query.ContainsKey("fn")
                            && context.Request.Query.ContainsKey("sn")
                            && context.Request.Query.ContainsKey("op"), Calc));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            });
        }

        private static void Calc(IApplicationBuilder app)
        {           
            app.UseMiddleware<ValidationMiddleware>();
            app.UseMiddleware<CalculatorMiddleware>();
        }
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("?fn=FirsNumber,  sn=SecondNumber, " +
                    "{operation}op =   '+ = s' '- = m' '* = u' '/ = d'  examle --  ?fn=3&sn=2&op=m --");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
    }
}
