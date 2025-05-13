using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
using Demo.Presentation.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices,IWebHostEnvironment _env,ILogger<DepartmentController> _logger) : Controller
    {
        // here i make inject for IDepartmentServices
        // i use webhostenvirment to check which environment i have now ,default add in service container
        // ILogger => to store logs error which happen in development

        // i need DermentServices(business logic) which i created to executed it here
        // so i need object from this class but it isnot true must create interface for that class
        //develop against that interface 
        public IActionResult Index()
        {
            var dept = _departmentServices.GetAllDepts();
            return View(dept);
        }

        #region Create 
        [HttpGet] //Get=> as return View which i will fill the form 
        public IActionResult Create() => View();//fat arrow

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO cdeptdto)
        {     //Server Side Validation on validation on attributes in CreatedDepartmentDTO

            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentServices.AddNewDepartment(cdeptdto);//=> return n rows is affected
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    // if create new department go to action index which show all depts
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department cannot created now ");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        //Log Error in console and return same model state with the same view 
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //log error in file in DB and return error view, default log errors in event viewer

                        _logger.LogError(ex.Message);
                    }

                }
            }
            //default return for each if,else
            return View(cdeptdto);

        }
        #endregion

        #region Details
        [HttpGet] // => show form details
        public IActionResult Details(int?id)
        {
            if (!id.HasValue) // => hasvalue show as nullable of int mean has value or null
                return BadRequest();
                var deptt = _departmentServices.GetDepartmentsById(id.Value);
            if (deptt is null) return NotFound();
            return View(deptt);
        }
        #endregion

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); //if id not has value
            // get id
            var dept = _departmentServices.GetDepartmentsById(id.Value);
            //if departemnt is not found as id not exist in Database like i have ids 1,2,...,10 and i send id 12 so that dept is null
            if (dept is null) return NotFound();
            //Manual Mapping from DepartmentDetailsDTO To DepartmentEditViewModel
            var deptViewModel = new DepartementEditViewModel()
            {
                Code = dept.Code,
                Name = dept.Name,
                Description = dept.Description,
                DateOfCreation = dept.CreatedOn,
            };
            return View(deptViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartementEditViewModel deptEditViewModel)
        {
            //check first from modelstate of deptEditViewModel
            if(ModelState.IsValid)
            {
                //Manual Mapping from DepartementEditViewModel to Updatedepartemntdto
                try
                {
                    var updateDepartmentDto = new UpdateDepartmentDTO()
                    {
                        Id = id,
                        Code = deptEditViewModel.Code,
                        Name = deptEditViewModel.Name,
                        Description = deptEditViewModel.Description,
                        DateOfCreation = deptEditViewModel.DateOfCreation,

                    };
                    int Result = _departmentServices.UpdateDepartment(updateDepartmentDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));//show all depts after update
                    else
                    {
                        //show message error
                        ModelState.AddModelError(string.Empty, "Department is not updated");
                    }

                }
                catch(Exception ex)
                {
                    //in development
                    if(_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //in deployment
                        _logger.LogError(ex.Message);
                    }

                }
            }
            return View(deptEditViewModel);
            #region Notes
            //not put id as input in editview as can show and change from inspect even it hidden
            //must send id from route to determine which depatment is edited and updated without it it will create new dept
            #endregion
        }

        //[HttpGet]
        //public IActionResult Delete(int?id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var dept = _departmentServices.GetDepartmentsById(id.Value);
        //    if (dept is null) return NotFound();
        //    return View(dept);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                bool isDeleted = _departmentServices.DeleteDepartment(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Department is not deleted");

                return RedirectToAction(nameof(Delete), new {id= id});// RedirectToAction go to method get
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new { id = id });
                }

                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
                   


               
            }
        }
    }

}
