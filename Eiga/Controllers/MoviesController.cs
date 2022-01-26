using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eiga.Models;
using Eiga.ViewModels;


namespace Eiga.Controllers
{
    public class MoviesController : Controller
    {
        public class ApplicationDbContext : MyDbContext
        {
        }
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
                
            return View("ReadOnlyList");
        }

        [Authorize(Roles= RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormviewModel
            {
                Genres  = genre
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
                return HttpNotFound();

            var viewmodel = new MovieFormviewModel(movie)
            {
                Genres = _context.Genre.ToList()
            };
            return View("MovieForm", viewmodel);
        }
        public ActionResult Details(int? id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(c => c.MovieId == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormviewModel(movie)
                {
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.MovieId == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(c => c.MovieId == movie.MovieId);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}