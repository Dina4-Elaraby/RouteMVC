using Demo.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Demo.DataAccess.Repositories.DepartmentRepo;
using Demo.BusinessLogic.Services.Department;
using Demo.DataAccess.Repositories.EmployeeRepo;
using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region  Add services to the container.(IservicesCollection)
            builder.Services.AddControllersWithViews(options =>
            {
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            });
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
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            // if someone demand IDepartmentServices inject or give him object of DepartmentServices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(m => m.AddProfile(new EmployeeProfile()));
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
