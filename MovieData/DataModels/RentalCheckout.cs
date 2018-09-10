using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("RentalCheckouts")]
    public class RentalCheckout
    {
        // Primary Key in table RentalCheckouts
        [Key]
        public int CheckoutId { get; set; }

        // Checkout date
        [Required]
        public DateTime CheckoutDate { get; set; }
        // Expected Return date
        public DateTime ReturnDate { get; set; }

        // ForeignKey to Renters account
        [ForeignKey("AspNetUsers")]
        public string RefAspNetUserId { get; set; }

        // ForeignKey reference to movie rental
        [ForeignKey("MovieAssest")]
        public int RefMovieAssestId { get; set; }
        public MovieAssest MovieAssest { get; set; }
    }
}
