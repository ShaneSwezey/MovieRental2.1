using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models.User;

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
            var currentCheckouts = _checkout.GetAllRentalCheckoutsByUser(userId);
            
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
