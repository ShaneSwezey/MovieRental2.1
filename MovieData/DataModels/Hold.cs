using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("Holds")]
    public class Hold
    {
        // Primary key for table Holds
        [Key]
        public int HoldId { get; set; }

        [Required]
        public DateTime HoldDate { get; set; }

        // ForeignKey to Renters account
        [ForeignKey("AspNetUsers")]
        public int RefAspNetUserId { get; set; }

        // ForeignKey reference to movie rental
        [ForeignKey("MovieAssest")]
        public int RefMovieAssestId { get; set; }
        public MovieAssest MovieAssest { get; set; }
    }
}
