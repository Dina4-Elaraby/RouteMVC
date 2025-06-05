using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.EmployeeRepo;
using AutoMapper;
namespace Demo.BusinessLogic.Services.EmployeeServices
{
    public class EmployeeServices(IEmployeeRepo _employeeRepo, IMapper _mapper) : IEmployeeServices
    {

        public IEnumerable<EmployeesDTO> GetAllEmployees(bool Tracking)
        {
            var emps = _employeeRepo.GetAll();//return IEnumerable<Employee>
            ////but i wanna return IEnumerable<employeedto> so i need make mapping=>work on mannual mapping
            ////convert from employee to employeedto
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
            ////using AutoMapper
            //var empsDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeesDTO>>(emps);

            #region Get all IEnumerable
            //var result = _employeeRepo.GetIEnumerable()
            //              .Where(e => e.IsDeleted != true) // where of ienumerable, get all employees and make filteration here
            //              .Select(e => new EmployeesDTO()
            //              {
            //                  Id = e.Id,
            //                  Name = e.Name,
            //                  Age = e.Age

            //              });
            //return result.ToList(); // to can show query ,tolist()=> immediate execution operator
            //GetIEnumerable => slect all attributes of employee and make filteration in app show only data i select it, all data load in memory
            #endregion

            #region GetAllIQueryable
            //var result = _employeeRepo.GetIQueryable()
            //        .Where(e => e.IsDeleted != true)
            //        .Select(e => new EmployeesDTO
            //        {
            //            Id = e.Id,
            //            Name = e.Name,
            //            Age = e.Age
            //        });
            //return result.ToList(); // return same data but way or return data different here make filteration in db
            //                        // SELECT [e].[Id], [e].[Name], [e].[Age]
            //      FROM[Employees] AS[e]
            //WHERE[e].[IsDeleted] = CAST(0 AS bit) 
            #endregion

            //var emps = _employeeRepo.GetAll(e => new EmployeesDTO()
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Salary = e.Salary
            //});
            //return emps;// return ienumerable but show as iquerable 
            //            // SELECT [e].[Id], [e].[Name], [e].[Salary]
            //      FROM[Employees] AS[e]
            //WHERE[e].[IsDeleted] = CAST(0 AS bit)
        }

        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var emp = _employeeRepo.GetById(id);//return nullable employee
            return emp is null ? null : _mapper.Map<Employee, EmployeeDetailsDTO>(emp);
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
