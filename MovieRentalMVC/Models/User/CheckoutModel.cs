using MovieData.DataModels;
using System;

namespace MovieRentalMVC.Models.User
{
    public class CheckoutModel
    {
        public MovieAssest MovieAssest { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
