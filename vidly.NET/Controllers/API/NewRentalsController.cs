using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.NET.Dtos;
using vidly.NET.Models;

namespace vidly.NET.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public NewRentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDTO newRental)
        {
            var customer = _dbContext.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _dbContext.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateAdded = DateTime.Now
                };

                _dbContext.Rentals.Add(rental);
            }
                     
            _dbContext.SaveChanges();

            return Ok();

        }
    }
}
