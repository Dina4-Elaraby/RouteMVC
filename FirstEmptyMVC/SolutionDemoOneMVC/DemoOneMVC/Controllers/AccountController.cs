using Microsoft.AspNetCore.Mvc;

namespace DemoOneMVC.Controllers
{
    public class AccountController : Controller
    {
        //BaseUrl/Account/SignIn
        public IActionResult SignIn()
        {
            return View();
        }
        //BaseUrl/Account/Register
        public IActionResult Register()
        {
            return View();
        }
    }
}
