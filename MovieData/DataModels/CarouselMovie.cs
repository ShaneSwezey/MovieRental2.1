using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for movie images for the home/index page carousel
    [Table("CarouselMovies")]
    public class CarouselMovie
    {
        // Primary key for MovieDB.CarouselMovies {{int}}
        [Key]
        public int MovieId { get; set; }
        // Image file location string for Home/Index carousel {{varchar(Max)}}
        public string CroppedPosterURL { get; set; }
    }
}
