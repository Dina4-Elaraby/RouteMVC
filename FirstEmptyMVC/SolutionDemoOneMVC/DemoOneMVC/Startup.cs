using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoOneMVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
    //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        //to add servicers to dependancy injection container
    //        //services.AddMvc();
    //        services.AddControllersWithViews();//add controller,view,support api controllers
            
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            //middleware for errors in development 
    //            app.UseDeveloperExceptionPage();
    //        }

    //        //middleware for routing (google map for app)
    //        app.UseRouting();

    //        //middleware for endpoint routing 
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello World!");
    //            });
    //        });
    //    }
    }
}
