using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidli.Dtos;
using Vidli.Models;
using System.Data.Entity;
using Vidli.Models.Roles;

namespace Vidli.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies/
        // [Authorize(Roles = RoleNames.CanManageMovies)]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<MovieModel, MovieDto>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<MovieModel, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, MovieModel>(moviedto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviedto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + moviedto.Id), moviedto);
        }

        // POST /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            var movieinDb = _context.Movies.Single(m => m.Id == Id);

            if (movieinDb == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            var movie = Mapper.Map(movieDto, movieinDb);
            /*movieinDb.Name = movie.Name;
            movieinDb.DateAdded = movie.DateAdded;
            movieinDb.GenreId = movie.GenreId;
            movieinDb.NumberInStock = movie.NumberInStock;
            movieinDb.ReleaseDate = movie.ReleaseDate;*/

            _context.SaveChanges();
            // you will need return Ok on all IHttpActionResult
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieinDb = _context.Movies.Single(m => m.Id == Id);

            if (movieinDb == null)
                return NotFound();
            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();


            return Ok();
        }

    }
}
