using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("RentalCheckouts")]
    class RentalCheckout
    {
        // Primary Key in table RentalCheckouts
        [Key]
        public int CheckoutId { get; set; }

        // Checkout date 
        public DateTime CheckoutDate { get; set; }
        // Expected Return date
        public DateTime ReturnDate { get; set; }

        // ForeignKey to Renters account
        [ForeignKey("AspNetUsers")]
        public int RefAspNetUserId { get; set; }
        
        // ForiegnKey reference to movie rental
    }
}
