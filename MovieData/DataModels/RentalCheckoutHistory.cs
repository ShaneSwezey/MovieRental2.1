using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("RentalCheckoutHistories")]
    public class RentalCheckoutHistory
    {
        [Key]
        public int RentalHistoryId { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        // Foreign Key to Renter's account
        [ForeignKey("AspNetUsers")]
        public string RefAspNetUserId { get; set; }

        // Foreign Key reference to movie rental
        [ForeignKey("MovieAssest")]
        public int RefMovieAssestId { get; set; }
        public MovieAssest MovieAssest { get; set; }
    }
}
