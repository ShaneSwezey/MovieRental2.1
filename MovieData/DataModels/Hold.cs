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
        public string RefAspNetUserId { get; set; }

        // Title of movie to be rented
        public string MovieTitle { get; set; }

        // Disk type
        public string DiskType { get; set; }
    }
}
