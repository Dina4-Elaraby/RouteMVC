using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServices departmentServices) : Controller
    {
        // here i make inject for IDepartmentServices

        // i need DermentServices(business logic) which i created to executed it here
        // so i need object from this class but it isnot true must create interface for that class
        //develop against that interface 
        public IActionResult Index()
        {
            return View();
        }
    }
}
