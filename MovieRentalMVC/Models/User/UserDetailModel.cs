using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieRentalMVC.Models.User
{
    public class UserDetailModel
    {
        public IEnumerable<HoldModel> Holds { get; set; }
        public IEnumerable<CheckoutModel> Checkouts { get; set; }
    }
}
