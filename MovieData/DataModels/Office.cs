using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for office from table Offices in database MovieDB2.0 
    [Table("Offices")]
    public class Office
    {
        // Primary key for MovieDb.Company {{int}}
        [Key]
        public int OfficeId { get; set; }
        // Office city location  {{varchar(Max)}}
        [Required]
        public string City { get; set; }
        // Office state location {{varchar(Max)}}
        [Required]
        public string State { get; set; }
        // Office address {{varchar(Max)}}
        [Required]
        public string Address { get; set; }
        // Office image assest location string {{varchar(Max)}}
        public string ImageAddress { get; set; }

        public ICollection<OfficeEmail> OfficeEmails { get; set; }
        public ICollection<OfficePhoneNumber> OfficePhoneNumbers { get; set; }
    }
}
