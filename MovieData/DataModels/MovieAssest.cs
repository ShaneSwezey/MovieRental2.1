﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("MovieAssests")]
    public abstract class MovieAssest
    {
        // Primary key in table MovieAssests
        [Key]
        public int AssestId { get; set; }
        // Is the current physical copy of the movie in inventory 
        public bool Active { get; set; }

        // Foreign Key reference to movie 
        [ForeignKey("Movie")]
        public int RefMovieId { get; set; }
        public Movie Movie { get; set; }

        /*
         * Foreign Key reference to office location where movie
         * disk is currently located
         */
        [ForeignKey("Office")]
        public int RefOfficeId { get; set; }
        public Office Location { get; set; }
    }
}
