using Demo.DataAccess.Repositories.DepartmentRepo;
using Demo.DataAccess.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.UnitOfWorkRepo
{
    public interface IUnitOfWork
    {
        public IDepartmentRepo departmentRepo { get; }
        public IEmployeeRepo employeeRepo { get; }
        int SaveChanges();
    }
}
