using MMDb.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Web.ViewModels
{
    public class IndexViewModel
    {
        public MovieViewModel MoviesViewModel { get; set; }

        public string SearchString { get; set; }

        public int? TotalResults { get; set; }

        public int? TotalPages { get; set; }
    }
}