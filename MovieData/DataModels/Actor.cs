using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieData.DataModels
{
    // Model for Actor table in MovieDB2.0
    [Table("Actors")]
    public class Actor
    {
        // Primary key in Actors  {{int}}
        [Key]
        public int ActorId { get; set; }
        // First name of Actor in Actors {{nvarchar(Max)}}
        public string FirstName { get; set; }
        // Last name of Actor in Actors {{nvarchar(MAX)}}
        public string LastName { get; set; }

        // Many to Many relationship to MovieDB.MovieActor
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
