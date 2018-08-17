﻿using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieRentalMVC.Models.Catalog
{
    public class MovieIndexListingModel
    {
        public int MovieId { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public IEnumerable<MovieGenre> Genre { get; set; }
    }
}
