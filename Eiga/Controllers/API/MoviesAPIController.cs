using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Eiga.DTOs;
using Eiga.Models;

namespace Eiga.Controllers.API
{
    public class MoviesAPIController : ApiController
    {
        private MyDbContext _context;

        public MoviesAPIController()
        {
            _context = new MyDbContext();
        }
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movie.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.MovieId == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);
        }

        [Authorize(Roles= RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movie.SingleOrDefault(c => c.MovieId == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(c => c.MovieId == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}