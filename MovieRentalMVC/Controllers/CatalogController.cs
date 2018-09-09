using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models.Catalog;
using System;
using System.Linq;

namespace MovieRentalMVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMovieResource _movies;
        private readonly ICheckOutResource _checkout;

        public CatalogController(IMovieResource moviesService, ICheckOutResource checkoutService)
        {
            _movies = moviesService ?? throw new ArgumentNullException();
            _checkout = checkoutService ?? throw new ArgumentNullException();
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

        
        public IActionResult Detail(int movieId)
        {
            var movie = _movies.GetById(movieId);
            
            var movieAvailiability = new MovieAvailabilityModel()
            {
                DvdAvailiable = _checkout.IsDvdCheckedOut(movieId),
                BlueRayAvailiable = _checkout.IsBlueRayCheckedOut(movieId)
            };
            
            var movieDetail = new MovieDetailModel()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Director = movie.Director,
                MovieGenre = movie.MovieGenres,
                ReleaseDate = movie.ReleaseDate,
                Synopsis = movie.Synopsis,
                Rating = movie.Rating,
                ImageUrl = movie.PosterUrl,
                MovieActors = movie.MovieActors,
                MovieAvailiability = movieAvailiability
            };

            return View(movieDetail);
        }
    }
}
