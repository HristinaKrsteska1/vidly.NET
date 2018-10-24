using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.NET.Models;
using vidly.NET.ViewModels;

namespace vidly.NET.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }       

        [HttpGet]
        public ActionResult NewMovie()
        {
            var genres = _dbContext.Genres.ToList();

            var viewModel = new MovieFromViewModel
            {
                Genres = genres,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
            
        }
    }
}