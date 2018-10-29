using AutoMapper;
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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            var movie = _dbContext.Movies.ToList().Select(Mapper.Map<Movie,MovieDTO>);

            return movie;
        }

        //GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //POST /api/movies/id
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/id
        [HttpPut]        
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map( movieDto, movieInDb);

            _dbContext.SaveChanges();

            return Ok();
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
