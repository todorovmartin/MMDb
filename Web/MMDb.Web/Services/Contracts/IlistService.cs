using MMDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMDb.Web.Services.Contracts
{
    public interface IlistService
    {
        void Create(MovieList movieList, string username);

        IEnumerable<MovieList> GetAllMovieLists(string username);
    }
}
