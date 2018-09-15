using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models.User;
using System.Linq;

namespace MovieRentalMVC.Controllers
{
    public class UserController : Controller
    {
        private ICheckOutResource _checkout;

        public UserController(ICheckOutResource checkout)
        {
            _checkout = checkout;
        }

        public IActionResult Index(string userId)
        {
            var currentCheckouts = _checkout.GetAllRentalCheckoutsByUser(userId)
                .Select(result => new CheckoutModel
                {
                    MovieAssest = result.MovieAssest,
                    CheckoutDate = result.CheckoutDate,
                    ReturnDate = result.ReturnDate
                });
            
            var currentHolds = _checkout.GetAllHoldsByUser(userId);

            var userDetails = new UserDetailModel
            {
                Checkouts = currentCheckouts,
                Holds = currentHolds
            };

            return View(userDetails);
        }
    }
}
