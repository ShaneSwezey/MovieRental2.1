using Microsoft.EntityFrameworkCore;
using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieServices
{
    // MovieResourceService class offers access to records contained in movie tables within database MovieDB2.0
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
            return _context.Movies
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieGenres)
                    .ThenInclude(mGenre => mGenre.Genre);
        }

        public Movie GetById(int id)
        {
            return _context.Movies
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                    .ThenInclude(mActor => mActor.Actor)
                .Include(movie => movie.MovieGenres)
                    .ThenInclude(mGenre => mGenre.Genre)
                .FirstOrDefault(m => m.MovieId == id);
        }

        public Director GetDirector(int id)
        {
            var directorId = _context.Movies
                .FirstOrDefault(m => m.MovieId == id)
                .RefDirectorId;

            var director = _context.Directors.FirstOrDefault(d => d.DirectorId == directorId);

            return director;
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
    }
}
