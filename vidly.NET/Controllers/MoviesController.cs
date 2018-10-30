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
                Movie = new Movie(),
                Genres = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFromViewModel
                {
                    Movie=movie,
                    Genres = _dbContext.Genres.ToList()
                };
                return View("NewMovie", viewModel);
                
            }
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFromViewModel
            {
                Movie=movie,   
                Genres = _dbContext.Genres.ToList()

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }       
    }
}

