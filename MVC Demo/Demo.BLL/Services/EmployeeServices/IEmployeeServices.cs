using Demo.BusinessLogic.DataTransferObjects.Employee;

namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        //5 Signature methods

       //1.GetAll
        IEnumerable<EmployeesDTO> GetAllEmployees(bool Tracking);

        //2.GetById
        EmployeeDetailsDTO GetEmployeeById(int id);

        //3.Create
        int CreatedEmployee(CreatedEmployeeDTO createdEmployeeDTO);

        //4.Update
        int UpdatedEmployee(UpdatedEmployeeDTO updatedEmployeeDTO);

        //5.Delete
        bool DeletedEmployee(int id);
       
    }
}
