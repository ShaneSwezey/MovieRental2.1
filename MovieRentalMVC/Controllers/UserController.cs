using Microsoft.AspNetCore.Mvc;
using MovieData;

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
            // checkouts
            // var currentCheckouts = _checkout.
            // holds
            return View();
        }
    }
}
