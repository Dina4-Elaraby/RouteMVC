using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DemoOneMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region new version
            // CreateHostBuilder(args).Build().Run();
            // here i will create my own hostbuilder
            //var webapp = WebApplication.CreateBuilder();
            #region ConfigureServices
            // here i will add service to my container
            // webapp.Services.AddControllersWithViews();
            #endregion

            #region Build
            //var app = webapp.Build(); //this is kerstal
            #endregion

            #region Configure
            //if (app.Environment.IsDevelopment())
            //{
            //    //middleware for errors in development 
            //    app.UseDeveloperExceptionPage();
            //}

            ////middleware for routing (google map for app)
            //app.UseRouting();

            //middleware for endpoint routing 

            //app.MapGet("/hi", async context =>
            //    {
            //    await context.Response.WriteAsync("Hello World!");
            //   });
            #endregion

            #region Run
            //app.Run();
            #endregion 
            #endregion

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseRouting();
            app.UseStaticFiles();//ckeck bootstrap.css in wwwroot
                                 // app.MapGet("/", () => "Hello world");
            #region MapControllerRoute
            app.MapControllerRoute
                   (
                   name: "Default",
                   // pattern: "{controller}/{action}/{Id}"//Movies/GetMovie/5
                   pattern: "{controller=Home}/{action=Index}/{Id?}" //Movies/GetMovie,id is nullable
                   //or
                 //pattern: "{controller=Movies}/{action=index}/{Id?}", //without space
                  // defaults: new { action = "index", controller = "Movies" }, // default action if not send action ,default controller if not send controller 
                   // if not send controller and action mean only baseurl is response Hello world from base routing not this route
                   //constraints: new {Id = new IntRouteConstraint()}//must id is int only
                   //constraints: new {Id = @"\d{2}"}//must id is d => digit and 2 digits only
                   ); 
            #endregion

            #region Routing
            #region base routing
            //app.MapGet("/", () => "Hello world"); 
            #endregion

            #region static segement routing
            // app.MapGet("/hi", () => "Hello world"); 
            #endregion

            #region variable segment
            //app.MapGet("/{name}", async context =>
            //    {
            //        var namee = context.GetRouteValue("name");
            //        await context.Response.WriteAsync($"hello {namee}");
            //    }); 
            #endregion

            #region mixed segment
            //app.MapGet("/X{name}", async context =>
            //   {
            //       //var namee = context.GetRouteValue("name");
            //       await context.Response.WriteAsync($"hello {context.Request.RouteValues["name"]}");
            //   }); 
            #endregion
            #endregion
            app.Run();

            #region Model Binding -Action Parameters Value Providers
            // 1.Form  2.Route Data 3.Query String => check automatically 4.Request Body  5.Request Header => must tell to check there 

            #endregion
        }

        #region old version
        // no function called IHostBuilder in .net 9, i create another one 

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        }); 
        #endregion
    }
}
