using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalMVC.Models.AboutUs
{
    public class OfficeDetailModel
    {
        public int OfficeId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string ImageAddress { get; set; }

        public IEnumerable<string> OfficeEmails { get; set; }
        public IEnumerable<string> OfficePhoneNumbers { get; set; }
    }
}
