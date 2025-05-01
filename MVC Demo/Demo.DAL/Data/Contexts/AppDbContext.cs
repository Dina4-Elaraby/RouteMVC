using Demo.DataAccess.Data.Configrations;
using System.Reflection;

namespace Demo.DataAccess.Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Two ways to apply configrations
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            #endregion

        }
        public DbSet<Department> Departments { get; set; }
    }
}
