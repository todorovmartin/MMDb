using Microsoft.EntityFrameworkCore;
using MMDb.Data;
using MMDb.Data.Models;
using MMDb.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace MMDb.Web.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext db;

        public FavoriteService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Add(int id, string username)
        {
            // Adding selected movie to db
            TMDbClient client = new TMDbClient(Environment.GetEnvironmentVariable("TMDB_API_KEY"));
            var selectedMovie = client.GetMovieAsync(id).Result;
            var currMovie = new Movie { };

            if (!this.db.Movies.Any(x => x.MovieNmr == id))
            {
                var movie = new Movie
                {
                    Title = selectedMovie.Title,
                    Description = selectedMovie.Overview,
                    MovieNmr = selectedMovie.Id,
                    ImageUrl = "http://image.tmdb.org/t/p/original" + selectedMovie.PosterPath,
                    Rating = selectedMovie.VoteAverage,
                    ReleaseDate = selectedMovie.ReleaseDate,
                };

                currMovie = movie;
                this.db.Movies.Add(movie);
                this.db.SaveChanges();
            }
            else
            {
                currMovie = this.db.Movies.FirstOrDefault(x => x.MovieNmr == id);
            }

            // Adding to favorites
            var user = this.db.Users.Include(x => x.Favorites).FirstOrDefault(x => x.UserName == username);
            if (user == null || user.Favorites.Any(x => x.MovieId == id))
            {
                return false;
            }

            var favoriteMovie = new FavoriteMovie
            {
                MovieId = currMovie.Id,
                UserId = user.Id,
            };

            user.Favorites.Add(favoriteMovie);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<FavoriteMovie> All(string username)
        {
            var userFavorites = this.db.FavoriteMovies.Include(x => x.Movie).Where(x => x.User.UserName == username);

            if (userFavorites == null)
            {
                return new List<FavoriteMovie>();
            }

            return userFavorites;
        }

        public void Remove(int id, string username)
        {
            var favMovie = this.db.FavoriteMovies.FirstOrDefault(x => x.User.UserName == username && x.MovieId == id);

            if (favMovie == null)
            {
                return;
            }

            this.db.FavoriteMovies.Remove(favMovie);
            this.db.SaveChanges();
        }
    }
}
