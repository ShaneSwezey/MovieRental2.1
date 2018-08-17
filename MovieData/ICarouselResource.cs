
using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICarouselResource
    {
        // Return IEnumerable of movie ids from table Movies for home page carousel
        IEnumerable<CarouselMovie> GetMovies();
        // Returns Dictionary of Movie id's and their CroppedPosterURL from home page carousel 
        Dictionary<int, string> GetMoviesTable();
    }
}
