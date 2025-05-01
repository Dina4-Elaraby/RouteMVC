
namespace Demo.DataAccess.Repositories
{
    public interface IDepartmentRepo
    {
        int Add(Department dept);
        IEnumerable<Department> GetAll(bool withtracking = false);
        Department? GetById(int id);
        int Remove(Department dept);
        int Update(Department dept);
    }
}