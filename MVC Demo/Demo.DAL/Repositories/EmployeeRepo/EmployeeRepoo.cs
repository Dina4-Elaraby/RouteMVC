using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.GenericRepo;

namespace Demo.DataAccess.Repositories.EmployeeRepo
{
    public class EmployeeRepoo(AppDbContext dbContext):GenericRepo<Employee>(dbContext),IEmployeeRepo
    {

    }
}
