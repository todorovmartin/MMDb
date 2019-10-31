using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Web.ViewModels.Favorites
{
    public class FavoriteMovieViewModel
    {
        public int Id { get; set; }

        public int MovieNmr { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }
    }
}
