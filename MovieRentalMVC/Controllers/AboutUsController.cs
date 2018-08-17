using Microsoft.AspNetCore.Mvc;
using MovieData;
using MovieRentalMVC.Models.AboutUs;
using System.Linq;

namespace MovieRentalMVC.Controllers
{
    public class AboutUsController : Controller
    {
        private IOfficeResource _officeServices;

        public AboutUsController(IOfficeResource officeServices)
        {
            _officeServices = officeServices;
        }

        public IActionResult Index()
        {

            var officeList = _officeServices.GetAll();

            var officeListing = officeList
                .Select(result => new OfficeDetailModel
                {
                    OfficeId = result.OfficeId,
                    Address = result.Address,
                    City = result.City,
                    State = result.State,
                    ImageAddress = result.ImageAddress,

                    OfficeEmails = result.OfficeEmails
                    .Select(c => c.EmailAddress),

                    OfficePhoneNumbers = result.OfficePhoneNumbers
                    .Select(c => c.PhoneNumber)
                });

            var officesList = new OfficeListingModel
            {
                OfficeList = officeListing.ToList()
            };

            return View(officeList);
        }

        [HttpPost]
        public IActionResult PartialOfficeInfo(int id)
        {

            var result = _officeServices.GetOfficeById(id);
            var OfficeModel = new OfficeDetailModel
            {
                OfficeId = result.OfficeId,
                Address = result.Address,
                City = result.City,
                State = result.State,
                ImageAddress = result.ImageAddress,

                OfficeEmails = result.OfficeEmails
                    .Select(c => c.EmailAddress),

                OfficePhoneNumbers = result.OfficePhoneNumbers
                    .Select(c => c.PhoneNumber)
            };


            return PartialView("_OfficeInfo", OfficeModel);
        }
    }
}
