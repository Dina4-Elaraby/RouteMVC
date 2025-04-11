using Microsoft.AspNetCore.Mvc;

namespace DemoOneMVC.Controllers
{
    public class MoviesController : Controller
    {
        //baseurl/Movies/GetMovie/4
        //Action => getmovie
        ///  Movies/GetMovie/10?name=noha
        //public string GetMovie(int? id,string name)
        //{
        //    return $"Movie with name = {name} and id = {id}";
        //}

        #region GetMovie No Logic
        //public ContentResult GetMovie(int? id, string name)
        //{
        //    //Action result 

        //    //ContentResult contentResult = new ContentResult();
        //    //contentResult.Content = $"Movie with name {name} and id = {id}";
        //    //contentResult.ContentType = "text/html";
        //    //return contentResult;

        //    //Helper method
        //    return Content($"Movie with name {name} and id = {id}", "text/html");

        //} 
        #endregion

        #region GetMovie With Logic
        public IActionResult GetMovie(int? id, string name) //Scalability more 
        {
            // id = 0 => bad request
            // id < 10 => not found
            // id >= 10 => return movie
            if (id == 0)
                return BadRequest();
            else if (id < 10)
                return NotFound();
            else
                return Content($"Movie with name {name} and <br> id = {id}", "text/html");

        }
        #endregion

        public IActionResult TestRedirectAction()
        {
            // return Redirect("https://localhost:44361/Movies/GetMovie/10?name=noha");

            // ---------------OR------------------------ 
            //this best if rediect path is local 4

            return RedirectToAction("GetMovie", "Movies", new { id = 30, name = "test" }); // => Movie with name test and
                                                                                           //id = 30
                                                                                           // may use nameof(action name)                                                                              
                                                                                           //return RedirectToAction(nameof(GetMovie), "Movies", .....);

            //return Redirect("");// go to path
        }

        //baseurl/movies/index
        //action=>index
        //master page of controller "Movies"
        public string index()
        {
            return "hi from index action";
        }

        [NonAction]//if anyone type baseurl/Movies/delete => not run
        public void delete()
        {

        }



        //baseurl/Movies/TestModelBinding
        [HttpPost]
        public IActionResult TestModelBinding(int id, string name)
        {
            return Content($"HI {name}, your id is {id}");
        }

        //[HttpPost]
        //public IActionResult AddMovie([FromBody]Movie movie) // raw in body   or [from header] => is not working with complex data(Movie movie)
        //{
        //    if (movie is null)
        //        return BadRequest();
        //    else
        //        return Content($"Movie is {movie.title} with id is {movie.id}");
        //}

        [HttpGet] // => route Date , query string  https://localhost:44361/Movies/AddMovie/10?title=film
        public IActionResult AddMovie(Movie movie) // raw in body   or  [from header] => is not working with complex data(Movie movie)
        {
            if (movie is null)
                return BadRequest();
            else
                return Content($"Movie is {movie.title} with id is {movie.id}");//Movie is film with id is 10
        }

        public IActionResult AddMovie(int id, string title, Movie movie, int[] arr)
        {
            return Content($"hi");
        }


    }
}
