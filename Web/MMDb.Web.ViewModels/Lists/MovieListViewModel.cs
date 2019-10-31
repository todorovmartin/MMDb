using System;
using System.Collections.Generic;
using System.Text;

namespace MMDb.Web.ViewModels.Lists
{
    public class MovieListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
