using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models;
using MovieRentalMVC.Models.Home;

namespace MovieRentalMVC.Controllers
{
    public class HomeController : Controller
    {
        private IMovieResource _movies;
        private ICarouselResource _carousel;

        public HomeController(IMovieResource movies, ICarouselResource carousel)
        {
            _movies = movies;
            _carousel = carousel;
        }

        // Needs improvement
        public IActionResult Index()
        {

            var movieTable = _carousel.GetMoviesTable();
            List<CarouselMovieModel> carouselMovieModelList = new List<CarouselMovieModel>();

            foreach (KeyValuePair<int, string> pair in movieTable)
            {
                int movieKey = pair.Key;
                carouselMovieModelList.Add(new CarouselMovieModel
                {
                    MovieId = movieKey,
                    CroppedImageUrl = pair.Value,
                    Synopsis = _movies.GetSynopsis(movieKey),
                    Title = _movies.GetTitle(movieKey)
                });
            }

            var listingModel = new CarouselMovieListModel()
            {
                CarouselMovieList = carouselMovieModelList
            };

            return View(listingModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
