using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsole
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<MeuMiddleware>();
            //app.Use(async (context, next) =>
            //{
            //    var a = 123;
            //    await next.Invoke();
            //    var b = 123;
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware 3");
            //    await next.Invoke();
            //});

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" }
            //        );
            //});

            app.UseMvcWithDefaultRoute();
        }
    }

    public class MeuMiddleware
    {
        private Stopwatch _stopWatch;
        private readonly RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _stopWatch = Stopwatch.StartNew();
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _stopWatch.Start();
            await _next(httpContext);
            _stopWatch.Stop();

            var final = _stopWatch.Elapsed.Seconds;
            
            await httpContext.Response.WriteAsync($"{final} Segundos");
        }
    }
}
