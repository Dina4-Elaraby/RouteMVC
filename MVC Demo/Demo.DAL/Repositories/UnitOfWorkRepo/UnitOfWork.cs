using Demo.DataAccess.Data.Contexts;

using Demo.DataAccess.Repositories.DepartmentRepo;

using Demo.DataAccess.Repositories.EmployeeRepo;

namespace Demo.DataAccess.Repositories.UnitOfWorkRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IDepartmentRepo> _departmentRepo;
        private readonly Lazy<IEmployeeRepo> _employeeRepo;
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _departmentRepo = new Lazy<IDepartmentRepo>(valueFactory: () => new DepartmentRepoo(appDbContext));
            _employeeRepo = new Lazy<IEmployeeRepo>(valueFactory: () => new EmployeeRepoo(appDbContext));



        }
        public IDepartmentRepo departmentRepo => _departmentRepo.Value;

        public IEmployeeRepo employeeRepo => _employeeRepo.Value;

        public int SaveChanges()
        {
           return _appDbContext.SaveChanges();
        }
    }
}
