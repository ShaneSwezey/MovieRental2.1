using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for movie director from table Directors in database MovieDB2.0 
    [Table("Directors")]
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        // First name of director in Directors 
        public string FirstName { get; set; }
        // Last name of director in Directors 
        public string LastName { get; set; }
    }
}
