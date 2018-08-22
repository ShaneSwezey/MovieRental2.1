using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for office emails from table OfficeEmails in database MovieDB2.0 
    [Table("OfficeEmails")]
    public class OfficeEmail
    {
        // Primary key for companyemail table from MovieDB {{int}}}
        [Key]
        public int OfficeEmailId { get; set; }
        // Email address for office {{varchar(Max)}} 
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        // foreignKey for Company table {{int}}
        [ForeignKey("Office")]
        public int OfficeRefId { get; set; }
        // Office navigation reference for Enity framework
        public Office Office { get; set; }
    }
}
