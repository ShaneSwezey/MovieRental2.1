using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;

namespace MovieServices
{
    // CarouselResourceService class offers access to records contained in carousel tables within database MovieDB2.0
    public class CarouselResourceService : ICarouselResource
    {

        private MovieDbContext _context;

        public CarouselResourceService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public IEnumerable<CarouselMovie> GetMovies()
        {
            return _context.CarouselMovies;
        }

        public Dictionary<int, string> GetMoviesTable()
        {
            Dictionary<int, string> movieDic = new Dictionary<int, string>();

            foreach(var movie in _context.CarouselMovies)
            {
                movieDic.Add(movie.MovieId, movie.CroppedPosterURL);
            }

            return movieDic;
        }
    }
}
