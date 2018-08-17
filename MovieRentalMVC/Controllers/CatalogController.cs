using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models.Catalog;
using System.Linq;

namespace MovieRentalMVC.Controllers
{
    public class CatalogController : Controller
    {
        private IMovieResource _movies;

        public CatalogController(IMovieResource movies)
        {
            _movies = movies;
        }

        public IActionResult Index()
        {
            var movieModels = _movies.GetAll();

            var listingResult = movieModels
                 .Select(result => new MovieIndexListingModel
                 {
                     MovieId = result.MovieId,
                     PosterUrl = result.PosterUrl,
                     Director = $"{result.Director.FirstName} {result.Director.LastName}",
                     Title = result.Title,
                     Genre = result.MovieGenres.ToList()
                 });

            var model = new MovieIndexModel()
            {
                Movies = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var movie = _movies.GetById(id);

            var movieDetail = new MovieDetailModel()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Director = $"{movie.Director.FirstName} {movie.Director.LastName}",
                Genre = movie.MovieGenres.ToList(),
                ReleaseDate = movie.ReleaseDate,
                Synopsis = movie.Synopsis,
                Rating = movie.Rating,
                ImageUrl = movie.PosterUrl,
            };

            return View(movieDetail);
        }
    }
}
