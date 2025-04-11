using Microsoft.AspNetCore.Mvc;

namespace DemoOneMVC.Controllers
{
    public class HomeController : Controller
    {
        //BaseUrl/Home/Index
        //Index=>master action of this controller
        public IActionResult Index()
        {
            return View();// return view with same name of action"Index"

            // return View(new Movie()); //take model to bind view with model data 
            // return View("testview"); //return view with specific name 
           // return View("testview", new Movie()); //// return view with same name of action & //take model to bind view with model data 
        }
       
        //BaseUrl/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        //BaseUrl/Home/AboutAs
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContentUs()
        {
            return View();
        }

        
    }
}
