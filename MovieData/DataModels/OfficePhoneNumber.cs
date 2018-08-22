using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for Office phone numbers from table OfficePhoneNumbers in database MovieDB2.0 
    [Table("OfficePhoneNumbers")]
    public class OfficePhoneNumber
    {
        // Primary key in table companyphonenumber in MovieDb {{int}}
        [Key]
        public int OfficePhoneNumberId { get; set; }
        // Phone number {{nvarchar(Max)}}
        [Required, Phone, Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        // ForeignKey for Company table 
        [ForeignKey("Office")]
        public int OfficeRefId { get; set; }
        // Office navigation reference for Enity framework
        public Office Office { get; set; }
    }
}
