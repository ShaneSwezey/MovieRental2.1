using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for movie genre from table Genres in database MovieDB2.0 
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreType { get; set; }

        // Navigation reference for entity framework
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
