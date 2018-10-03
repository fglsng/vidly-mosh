using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels.Movies;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenreTypes = genreTypes
            };
            return View("MovieForm", viewModel);

        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList(),
                Movie = movie
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.GenreTypeId = movie.GenreTypeId;
                movieFromDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("movies")]
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(m => m.GenreType).ToList();

            var viewModel = new IndexMovieViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }







        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };



            #region Bad ways to parse data
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            #endregion



            return View(viewModel);


            #region Other return types
            //return new ViewResult();
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
            #endregion
        }



        #region Notes / Comments
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}



        #endregion
    }
}