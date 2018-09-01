using Microsoft.AspNetCore.Identity;

namespace MovieData.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        // Address
        public string Address { get; set; }
        // City
        public string City { get; set; }
        // State
        public string State { get; set; }
        // Zip code
        public int ZipCode { get; set; }
        
    }
}
