using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Data.Models
{
    public class MovieListMovie
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int MovieListId { get; set; }

        public MovieList MovieList { get; set; }
    }
}
