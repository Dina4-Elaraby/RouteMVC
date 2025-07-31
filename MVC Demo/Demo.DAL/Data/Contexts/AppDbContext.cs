using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.EmployeeModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Demo.DataAccess.Models.IdentityModel;

namespace Demo.DataAccess.Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //IdentityDbContext => make model of user  and roles and others from package of identity


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Two ways to apply configrations
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            #endregion
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
     
    }
}
