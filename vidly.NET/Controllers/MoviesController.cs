using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.NET.Models;
using vidly.NET.ViewModels;

namespace vidly.NET.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Die Hard"
            };

            var customers = new List<Customer>
            {
                new Customer{ Name="Hristina"},
                new Customer{ Name="Bojana"}
            };

            var viewModels = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModels);
        }
    }
}