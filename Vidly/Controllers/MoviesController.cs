using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

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
            return View(movie);

            // to return simple string
            //return Content(movie.ToString());

            // to return 404
            //return HttpNotFound();

            // to return empty page
            //return new EmptyResult();

            // to return to different controller
            //var argumentsAction = new { page = 1, sortBy = "name" };
            //return RedirectToAction("Index", "Home", argumentsAction);
        }

        /*
         * RouteConfig temos que nome default /{id},
         * Se mudarmos para outro nome nao funciona, temos de ir ao RouteConfig
         */
        public ActionResult Edit(int id)
        {
            return Content("Id is " + id);
        }

        // GET: Movies
        /*
         * Temos 2 arguments opcionais
         * Vamos testar a sua logica e meter valor default
         * Imprimimos valor da queryString
         */
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (sortBy.IsNullOrWhiteSpace())
                sortBy = "name";

            return Content(String.Format("/movies?pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // GET: Movies/released/year/month
        /*
         Attribute routing com regex,
         Mais poderoso que normal routing pq se o quizermos fazer alteracoes, so fazemos aqui
         */
        /*
         *
         */
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content("year: " + year + " month: " + month);
        }

        // GET: Movies/PassDataDictionary
        public ActionResult PassDataViews()
        {
            var movie = new Movie() { Name = "Shrek" };

            // Passing data to View as a Dictionary with ViewData
            ViewData["Movie"] = movie;

            var randomMovie = new Movie() { Name = "RandomShrek" };

            // Passing data to View as a Dictionary with ViewBag 
            ViewBag.RandomMovie = randomMovie;

            // Para onde vai data? Exactamente mesmo
            //var viewResult = new ViewResult();
            //viewResult.ViewBag.RandomMovie = randomMovie;
            //viewResult.ViewData.Model = randomMovie;

            // Ctrl B
            return View();
        }

        public ActionResult RandomViewModel()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}