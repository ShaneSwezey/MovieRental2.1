using MovieData.DataModels;
using System;
using System.Collections.Generic;

namespace MovieData
{
    public interface IMovieResource
    {
        
        // Returns title of movie
        string GetTitle(int id);
        // Returns the Motion Picture Association of America film rating of the film
        string GetRating(int id);        
        // Returns the synopsis of the film
        string GetSynopsis(int id);
        // Returns the poster assest location
        string GetPosterUrl(int id);

        // Returns full name of the director
        Director GetDirector(int id);

        // Returns the release date of the movie
        DateTime GetReleaseDate(int id);
        
        // Returns Movie model with respected parameter id
        Movie GetById(int id);

        // Returns an IEnumerable of all Movie models
        IEnumerable<Movie> GetAll();
    }
}
