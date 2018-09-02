using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("RentalCheckoutHistories")]
    class RentalCheckoutHistory
    {
        [Key]
        public int RentalHistoryId { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        // ForeignKey to Renters account
        [ForeignKey("AspNetUsers")]
        public int RefAspNetUserId { get; set; }

        // ForiegnKey reference to movie rental
    }
}
