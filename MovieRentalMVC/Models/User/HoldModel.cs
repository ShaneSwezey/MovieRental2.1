using System;

namespace MovieRentalMVC.Models.User
{
    public class HoldModel
    {
        public string Title { get; set; }
        public DateTime HoldDate { get; set; }
        public string DiskType { get; set; }
    }
}
