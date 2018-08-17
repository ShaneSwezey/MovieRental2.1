using MovieData.DataModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieData.Data
{
    public class Seed
    {

        private MovieDbContext _context;
        private string solutionName;

        public Seed(MovieDbContext context)
        {
            _context = context;
            solutionName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }

        public void SeedAll()
        {
            SeedDirectors();
            SeedMovies();
            SeedActors();
            SeedGenre();
            SeedOffices();
        }

        private void SeedDirectors()
        {
            if (!_context.Directors.Any())
            {
                var directorData = System.IO.File.ReadAllText($"{solutionName}/MovieRental/MovieData/Data/DirectorSeedData.json");
                var directorsList = JsonConvert.DeserializeObject<List<Director>>(directorData);

                if (directorsList != null)
                {
                    _context.Directors.AddRange(directorsList);
                }

                _context.SaveChanges();
            }
        }

        private void SeedMovies()
        {
            if (!_context.Movies.Any())
            {
                var movieData = System.IO.File.ReadAllText($"{solutionName}/MovieRental/MovieData/Data/MovieSeedData.json");
                var movieList = JsonConvert.DeserializeObject<List<Movie>>(movieData);

                var movieDirectors = GetDirectorRefId();

                foreach(Movie movie in movieList)
                {
                    movie.RefDirectorId = movieDirectors[movie.Title];
                    _context.Movies.Add(movie);
                }

                _context.SaveChanges();
            }
        }

        private void SeedActors()
        {
            if (!_context.Actors.Any())
            {
                var actorData = System.IO.File.ReadAllText($"{solutionName}/MovieRental/MovieData/Data/ActorSeedData.json");
                var actorList = JsonConvert.DeserializeObject<List<Actor>>(actorData);

                foreach (Actor actor in actorList)
                {
                    _context.Actors.Add(actor);
                }

                _context.SaveChanges();
            }
        }

        private void SeedGenre()
        {
            if (!_context.Genres.Any())
            {
                var genreData = System.IO.File.ReadAllText($"{solutionName}/MovieRental/MovieData/Data/GenreSeedData.json");
                var genreList = JsonConvert.DeserializeObject<List<Genre>>(genreData);

                foreach (Genre genre in genreList)
                {
                    _context.Genres.Add(genre);
                }

                _context.SaveChanges();
            }
        }

        private void SeedOffices()
        {
            if (!_context.Offices.Any())
            {
                var officeData = System.IO.File.ReadAllText($"{solutionName}/MovieRental/MovieData/Data/OfficeSeedData.json");
                var officeList = JsonConvert.DeserializeObject<List<Office>>(officeData);

                foreach (Office office in officeList)
                {
                    _context.Offices.Add(office);
                }

                _context.SaveChanges();
            }
        }

        private IDictionary<string, int> GetDirectorRefId()
        {
            Dictionary<string, int> movieDirector = new Dictionary<string, int>()
            {
                { "Blade Runner", 1 },
                { "Halloween", 2},
                { "Alien", 1},
                { "Breakfast at Tiffany's", 3},
                { "Saving Private Ryan", 4},
                { "Blade Runner 2049", 5},
                { "Aliens", 6},
                { "The Evil Dead", 7},
                { "Evil Dead II", 7},
            };

            return movieDirector;
        }

    }
}
