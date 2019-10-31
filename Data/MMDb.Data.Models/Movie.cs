using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public int MovieNmr { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }

        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }

        public ICollection<MovieListMovie> MListMovies { get; set; }
    }
}
