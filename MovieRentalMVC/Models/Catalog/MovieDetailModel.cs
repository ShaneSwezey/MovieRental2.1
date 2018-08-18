using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalMVC.Models.Catalog
{
    public class MovieDetailModel
    {
        public int MovieId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

        [Display(Name = "ReleaseDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<MovieGenre> MovieGenre { get; set; }
        public string Rating { get; set; }
        public string Synopsis { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
