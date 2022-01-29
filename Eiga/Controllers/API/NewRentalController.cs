using Eiga.DTOs;
using Eiga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Eiga.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private MyDbContext _context;
        public NewRentalController()
        {
            _context = new MyDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customer.Single(
                c => c.CustomerId == newRental.CustomerId);

            var movies = _context.Movie.Where(
                m => newRental.MovieIds.Contains(m.MovieId)).ToList();

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
        
    }
}