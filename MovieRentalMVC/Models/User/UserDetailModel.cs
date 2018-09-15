using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieRentalMVC.Models.User
{
    public class UserDetailModel
    {
        public IEnumerable<Hold> Holds { get; set; }
        public IEnumerable<RentalCheckout> Checkouts { get; set; }
    }
}
