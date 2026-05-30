using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.EmployeeRepo
{
    public class EmployeeRepo(AppDbContext dbContext):GenericRepo<Employee>(dbContext),IEmployeeRepo
    {
    }
}
