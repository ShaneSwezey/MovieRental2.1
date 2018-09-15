using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieRentalMVC.Models.User
{
    public class UserDetailModel
    {
        public IEnumerable<Hold> Holds { get; set; }
        public IEnumerable<CheckoutModel> Checkouts { get; set; }
    }
}
