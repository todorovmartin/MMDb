using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Data.Models
{
    public class MovieList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<MovieListMovie> MListMovies { get; set; }
    }
}
