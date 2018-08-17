using MovieData.DataModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MovieData.Data
{
    public class Seed
    {

        private MovieDbContext _context;

        public Seed(MovieDbContext context)
        {
            _context = context;
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
                var directorData = System.IO.File.ReadAllText("Data/DirectorSeedData.json");
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
                var movieData = System.IO.File.ReadAllText("Data/MovieSeedData.json");
                var movieList = JsonConvert.DeserializeObject<List<Movie>>(movieData);

                foreach(Movie movie in movieList)
                {
                    _context.Movies.Add(movie);
                }

                _context.SaveChanges();
            }
        }

        private void SeedActors()
        {
            if (!_context.Actors.Any())
            {
                var actorData = System.IO.File.ReadAllText("Data/ActorSeedData.json");
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
                var genreData = System.IO.File.ReadAllText("Data/GenreSeedData.json");
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
                var officeData = System.IO.File.ReadAllText("Data/OfficeSeedData.json");
                var officeList = JsonConvert.DeserializeObject<List<Office>>(officeData);

                foreach (Office office in officeList)
                {
                    _context.Offices.Add(office);
                }

                _context.SaveChanges();
            }
        }

    }
}
