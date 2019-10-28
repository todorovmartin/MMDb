using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Web.ViewModels.Movies
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }
    }
}