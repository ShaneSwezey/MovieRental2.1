using System.Collections.Generic;

namespace MovieRentalMVC.Models.Catalog
{
    public class MovieIndexModel
    {
        public IEnumerable<MovieIndexListingModel> Movies { get; set; }
    }
}
