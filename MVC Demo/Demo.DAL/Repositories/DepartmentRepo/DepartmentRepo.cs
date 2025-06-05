using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.GenericRepo;

namespace Demo.DataAccess.Repositories.DepartmentRepo
{
    //primary constructor
    //Repository => crud operations of department model(functions),No logic 
    public class DepartmentRepo(AppDbContext dbContext) : GenericRepo<Department>(dbContext),IDepartmentRepo
    {
        
    }
}
