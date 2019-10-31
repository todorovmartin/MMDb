using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Web.ViewModels.Movies
{
    public class MovieViewModel
    {
        public int Id { get; set; }

<<<<<<< HEAD
        public int MovieNmr { get; set; }

=======
>>>>>>> 04617f2c5c0b150e5807d9f762cf2631c36a95e9
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }
    }
}
