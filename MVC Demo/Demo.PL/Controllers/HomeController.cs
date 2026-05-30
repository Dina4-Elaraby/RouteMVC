using System.Diagnostics;
using System.Text;
using Demo.Presentation.ServiceLifeTime;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingleton singlton01;
        private readonly ISingleton singlton02;
        private readonly IScoped scoped01;
        private readonly IScoped scoped02;
        private readonly ITransient transient01;
        private readonly ITransient transient02;

        public HomeController(ISingleton singlton01, ISingleton singlton02, IScoped scoped01, IScoped scoped02, ITransient transient01, ITransient transient02)
        {
            this.singlton01 = singlton01;
            this.singlton02 = singlton02;
            this.scoped01 = scoped01;
            this.scoped02 = scoped02;
            this.transient01 = transient01;
            this.transient02 = transient02;
            //Console.WriteLine($"Singeltion01{singlton01}\n Singleton02 {singlton02}\n " +
            //    $"Scoped01 {scoped01}\n Scopd02 {scoped02}\n " +
            //    $"Transient01 {transient01}\n Transient02 {transient02}");
        }

        public IActionResult Index()
        {
            return View();
            //StringBuilder sb = new StringBuilder();
            //sb.Append(($"Singeltion01{singlton01.GetGuid()}\n Singleton02 {singlton02.GetGuid()}\n " +
            //  $"Scoped01 {scoped01.GetGuid()}\n Scopd02 {scoped02.GetGuid()}\n " +
            // $"Transient01 {transient01.GetGuid()}\n Transient02 {transient02.GetGuid()}"));
            //return sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
