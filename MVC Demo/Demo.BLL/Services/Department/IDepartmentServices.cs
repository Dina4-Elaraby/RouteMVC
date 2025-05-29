using Demo.BusinessLogic.DataTransferObjects.Department;

namespace Demo.BusinessLogic.Services.Department
{
    public interface IDepartmentServices
    {
        int AddNewDepartment(CreatedDepartmentDTO deptdto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentsDTO> GetAllDepts();
        DepartmentDetailsDTO? GetDepartmentsById(int id);
        int UpdateDepartment(UpdatedDepartmentDTO updeptdto);
    }
}