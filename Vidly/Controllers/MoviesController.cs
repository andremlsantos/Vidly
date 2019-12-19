using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        /*
         * ViewResult : ViewResultBase : ActionResult
         * E considerado boa practica usar ViewResult mas se podermos ter retornar variuos tipos acoes neste metodo
         * Temos de retornar ActionResult por polimorphismo
         */
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };

            // to return view
            //return View(movie);

            // to return simple string
            //return Content(movie.ToString());

            // to return 404
            //return HttpNotFound();

            // to return empty page
            //return new EmptyResult();

            // to return to different controller
            var argumentsAction = new { page = 1, sortBy = "name" };
            return RedirectToAction("Index", "Home", argumentsAction);
        }
    }
}