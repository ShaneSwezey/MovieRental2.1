using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for Movie table in MovieDB2.0
    [Table("Movies")]
    public class Movie
    {
        [Key]
        // Primary key in table Movie {{int}}
        public int MovieId { get; set; }
        // Title in table Movie {{nvarchar(Max)}}
        public string Title { get; set; }
        // Movie synopsis in table Movie {{nvarchar(Max)}}
        public string Synopsis { get; set; }
        // Motion Picture Association of America film rating of movie in table Movie {{nvarchar(Max)}}
        public string Rating { get; set; }
        // Release date of movie {{datetime2}}
        public DateTime ReleaseDate { get; set; }
        // Image assest location string for Movie {{nvarchar(Max)}}
        public string PosterUrl { get; set; }
        

        [ForeignKey("Director")]
        public int RefDirectorId { get; set; }
        public Director Director { get; set; }


        // Navigation references for entity framework
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
