using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.EmployeeRepo;
using AutoMapper;
namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public class EmployeeServices(IEmployeeRepo _employeeRepo,IMapper _mapper) : IEmployeeServices
    {

        public IEnumerable<EmployeesDTO> GetAllEmployees(bool Tracking)
        {
            var emps = _employeeRepo.GetAll();//return IEnumerable<Employee>
            //but i wanna return IEnumerable<employeedto> so i need make mapping=>work on mannual mapping
            //convert from employee to employeedto
            var empsdto = emps.Select(emp => new EmployeesDTO()
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Age = emp.Age,
                Salary = emp.Salary,
                IsActive = emp.IsActive,
                Gender = emp.Gender.ToString(),
                EmployeeType = emp.EmployeeType.ToString()


            });
            return empsdto;
            //using AutoMapper
            var empsDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeesDTO>>(emps);
        }

        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var emp = _employeeRepo.GetById(id);//return nullable employee
            return emp is null ? null : _mapper.Map<Employee,EmployeeDetailsDTO>(emp);
        }

        public int CreatedEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
            var emp = _mapper.Map<CreatedEmployeeDTO, Employee>(createdEmployeeDTO);
            return _employeeRepo.Add(emp);
        }

        public int UpdatedEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            var emp = _mapper.Map<UpdatedEmployeeDTO, Employee>(updatedEmployeeDTO);
            return _employeeRepo.Update(emp);
        }
        public bool DeletedEmployee(int id)
        {
            var emp = _employeeRepo.GetById(id);//get id which deleted
            if (emp is null) return false;
            else
            {
                emp.IsDeleted = true;
                return _employeeRepo.Update(emp) > 0 ? true : false;
            }
        }

       
       
    }
}
