using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    [Table("Holds")]
    class Hold
    {
        // Primary key for table Holds
        [Key]
        public int HoldId { get; set; }

        public DateTime HoldPlace { get; set; }

        // ForeignKey to Renters account
        [ForeignKey("AspNetUsers")]
        public int RefAspNetUserId { get; set; }

        // ForiegnKey reference to movie rental
    }
}
