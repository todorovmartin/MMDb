using MMDb.Data;
using MMDb.Data.Models;
using MMDb.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMDb.Web.Services
{
    public class ListService : IlistService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public ListService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void Create(MovieList movieList, string username)
        {
            var user = this.usersService.GetUserByUsername(username);

            movieList.User = user;

            this.db.MovieLists.Add(movieList);
            this.db.SaveChanges();
        }

        public IEnumerable<MovieList> GetAllMovieLists(string username)
        {
            var user = this.usersService.GetUserByUsername(username);
            var lists = this.db.MovieLists.Where(x => x.UserId == user.Id);

            return lists;
        }

        public MovieList GetMovieListById(int id)
        {
            return this.db.MovieLists.FirstOrDefault(x => x.Id == id);
        }

        public bool ListExists(int id)
        {
            return this.db.MovieLists.Any(e => e.Id == id);
        }

        public bool Edit(MovieList movieList, string username)
        {
            if (!this.ListExists(movieList.Id))
            {
                return false;
            }

            var user = this.usersService.GetUserByUsername(username);

            movieList.User = user;

            try
            {
                this.db.Update(movieList);
                this.db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
