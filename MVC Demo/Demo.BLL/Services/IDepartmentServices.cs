using Demo.BusinessLogic.DataTransferObjects;

namespace Demo.BusinessLogic.Services
{
   public interface IDepartmentServices
    {
        int AddNewDepartment(CreatedDepartmentDTO deptdto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepts();
        DepartmentsDetailsDTO? GetDepartmentsById(int id);
        int UpdateDepartment(UpdateDepartmentDTO updeptdto);
    }
}