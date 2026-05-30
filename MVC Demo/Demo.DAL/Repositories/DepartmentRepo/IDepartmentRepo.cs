using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.GenericRepo;

namespace Demo.DataAccess.Repositories.DepartmentRepo
{
    public interface IDepartmentRepo:IGenericRepo<Department>
    {
        
    }
}