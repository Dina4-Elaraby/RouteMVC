using Demo.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Demo.BusinessLogic.Services.Department;
using Demo.BusinessLogic.Services.Attachment_Services;
using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Demo.Presentation.ServiceLifeTime;
using Demo.DataAccess.Repositories.UnitOfWorkRepo;
using Demo.DataAccess.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
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
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

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
                options.UseLazyLoadingProxies();
            });

            //builder.Services.AddScoped<IDepartmentRepo, DepartmentRepoo>();
            //builder.Services.AddScoped<IEmployeeRepo, EmployeeRepoo>();

            // if someone demand IDepartmentServices inject or give him object of DepartmentServices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddAutoMapper(m => m.AddProfile(new EmployeeProfile()));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            //builder.Services.AddIdentity<ApplicationUser, IdentityUser>(options =>
            //{
            //  // these are defaults 
            //    //options.User.RequireUniqueEmail= true;
            //    //options.Password.RequireLowercase = true;
            //    //options.Password.RequireUppercase = true;
            //}).AddEntityFrameworkStores<AppDbContext>();

            //new instance of service is created once per request
            builder.Services.AddScoped<IScoped, Scoped>();

            //create /new instance of service only once per program
            builder.Services.AddSingleton<ISingleton, Singleton>();

            //add new instance of service each time is requested
            builder.Services.AddTransient<ITransient, Transient>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Register}/{id?}");

            #endregion
            app.Run();
        }
    }
}
