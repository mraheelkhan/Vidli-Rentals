using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidli.Models;
using System.Data.Entity;
using Vidli.Models.Roles;
using Vidli.ViewModels;
namespace Vidli.Controllers
{
    public class MovieController : Controller
    {
        // GET: 
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //var movie = new Movies() { Name = "Dil wale Dulhian " };
            //var movies = new List<Movies>
            //{
            //    new Movies
            //    {
            //        Id = 1,
            //        Name = "Shrek"
            //    },
            //    new Movies
            //    {
            //        Id = 2,
            //        Name = "Stronghold"
            //    }
            //};


            //var Movies = new MovieViewModel
            //{
            //    Movies = movies
            //};

            // commented it because of client side rendering from api
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            // return View(movies);

            if (User.IsInRole(RoleNames.CanManageMovies))
                return View();
            
            return View("ReadOnlyList");
        }


        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(s => s.Id == Id);
            return View(movies);
        }

        //public ActionResult PassDataToView()
        //{
        //    var movie = new Movies() { Name = "Blockbuster" };
        //    ViewBag.Message = "Raheel Khan Message";
        //    return View(movie);
        //}

        [Authorize(Roles= RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            
            var genres = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                // Movie = new MovieModel(),
                Genre = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(MovieModel movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            if (!ModelState.IsValid)
            {
                var genres = _context.Genre.ToList();

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = genres
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                //var CustomerInDb = _context.Movies.Single(c => c.Id == movie.Id);
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.DateAdded = movie.DateAdded;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public IEnumerable<MovieModel> GetAllMovies()
        {
            return new List<MovieModel>
            {
                new MovieModel
                {
                    Id = 1,
                    Name = "Shrek"
                },
                new MovieModel
                {
                    Id = 2,
                    Name = "Stronghold"
                }
            };
        }
    }
}