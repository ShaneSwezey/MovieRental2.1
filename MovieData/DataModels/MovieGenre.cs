namespace MovieData.DataModels
{
    // Many to many model for Movies, and Genres
    public class MovieGenre
    {
        // MovieId reference key in table Movie
        public int MovieId { get; set; }
        // Navigation reference entity framework
        public Movie Movie { get; set; }
        // GenreId reference key in table Genre
        public int GenreId { get; set; }
        // Navigation reference entity framework
        public Genre Genre { get; set; }
    }
}
