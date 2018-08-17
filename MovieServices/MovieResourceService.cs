using Microsoft.EntityFrameworkCore;
using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieServices
{
    public class MovieResourceService : IMovieResource
    {
        // Dbcontext
        private MovieDbContext _context;

        public MovieResourceService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public Movie GetById(int id)
        {
            return _context.Movies
                .Include(m => m.MovieActors)
                .Include(m => m.MovieGenres)
                .FirstOrDefault(m => m.MovieId == id);
        }

        public string GetDirector(int id)
        {
            var directorId = _context.Movies.FirstOrDefault(m => m.MovieId == id).RefDirectorId;
            var director = _context.Directors.FirstOrDefault(d => d.DirectorId == directorId);

            return $"{director.FirstName} {director.LastName}";
        }

        public IEnumerable<string> GetGenre(int id)
        {
            var movie = GetById(id);
            if (movie == null) return null;

            List<string> movieGenres = new List<string>();

            foreach(MovieGenre g in movie.MovieGenres)
            {
                Genre genre = GetGenreById(g.GenreId);
                if (genre != null) movieGenres.Add(genre.GenreType);
            }

            return movieGenres;
        }

        public string GetPosterUrl(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .PosterUrl;
        }

        public string GetRating(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .Rating;
        }

        public DateTime GetReleaseDate(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .ReleaseDate;
        }

        public string GetSynopsis(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .Synopsis;
        }

        public string GetTitle(int id)
        {
            return _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .Title;
        }
       
        private Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.GenreId == id);
        }

    }
}
