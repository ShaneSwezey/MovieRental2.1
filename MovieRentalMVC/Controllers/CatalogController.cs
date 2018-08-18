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
                     Director = result.Director,
                     Title = result.Title,
                     MovieGenre = result.MovieGenres
                 });

            var movieListings = new MovieIndexModel()
            {
                Movies = listingResult
            };

            return View(movieListings);
        }

        public IActionResult Detail(int id)
        {
            var movie = _movies.GetById(id);

            var movieDetail = new MovieDetailModel()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Director = movie.Director,
                Genre = _movies.GetGenre(movie.MovieId),
                ReleaseDate = movie.ReleaseDate,
                Synopsis = movie.Synopsis,
                Rating = movie.Rating,
                ImageUrl = movie.PosterUrl,
                Actors = _movies.GetActors(movie.MovieId)
            };

            return View(movieDetail);
        }
    }
}
