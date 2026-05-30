using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.BusinessLogic.Services.EmployeeServices;
using Demo.DataAccess.Models.CommonModel;
using Demo.DataAccess.Models.EmployeeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices, IWebHostEnvironment _env, ILogger<EmployeeController> _logger) : Controller
    {
        //Return All Employees
        public IActionResult Index()
        {
            var emp = _employeeServices.GetAllEmployees(false); // return IEnumerable<employeesdto>
            return View(emp);
        }

        #region Create
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDTO createdEmployeeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _employeeServices.CreatedEmployee(createdEmployeeDTO);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Employee cannot added now!!");

                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(createdEmployeeDTO);
        }

        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var emp = _employeeServices.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();// id is valid as int but not found in db
            return View(emp);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeeServices.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();
            //map from employeedetailsdto to updatedemployeedto
            var employeeDTO = new UpdatedEmployeeDTO()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Email = emp.Email,
                Address = emp.Address,
                PhoneNumber = emp.PhoneNumber,
                IsActive = emp.IsActive,
                Salary = emp.Salary,
                HiringDate = emp.HiringDate,
                Gender = Enum.Parse<Gender>(emp.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(emp.EmployeeType)
            };
            return View(employeeDTO);
        }

        [HttpPost]
        public IActionResult Edit(int? id, UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            if (!id.HasValue || id != updatedEmployeeDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return View(updatedEmployeeDTO); // return view with same data u enter it 
            {
                // try to make update
                try
                {
                    var result = _employeeServices.UpdatedEmployee(updatedEmployeeDTO);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {  //show message error if employee not updated
                        ModelState.AddModelError(string.Empty, "Employee date is not updated");
                        return View(updatedEmployeeDTO);
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(updatedEmployeeDTO);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }

                }
            }
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                bool isDeleted = _employeeServices.DeletedEmployee(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Employee is not deleted");

                return RedirectToAction(nameof(Delete), new { id = id });// RedirectToAction go to method get
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new
                    {
                        id = id
                    });
                }

                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }

        } 
        #endregion
    }
}
