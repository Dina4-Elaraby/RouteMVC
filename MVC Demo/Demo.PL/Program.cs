using Demo.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Demo.DataAccess.Repositories;
using Demo.BusinessLogic.Services;
namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region  Add services to the container.(IservicesCollection)
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<AppDbContext>();//2. add services to container
            builder.Services.AddDbContext<AppDbContext>
            (options =>
            {
             //1.
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConntection"]);
             //2.
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConntection"]);
             //3.
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConntection"));
            });
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            // if someone demand IDepartmentServices inject or give him object of DepartmentServices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            #endregion
            var app = builder.Build();


            #region Configure the HTTP request pipeline.(MiddleWare)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //The order here very important
            app.UseHttpsRedirection();
            app.UseStaticFiles();//routing for files exist in wwwroot
            app.UseRouting();//go to route is defined in routing table
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
