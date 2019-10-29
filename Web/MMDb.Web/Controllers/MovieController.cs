using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace MMDb.Web.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Details(int id)
        {
            TMDbClient client = new TMDbClient(Environment.GetEnvironmentVariable("TMDB_API_KEY"));
            Movie movie = client.GetMovieAsync(id).Result;

            var recommendations = client.GetMovieRecommendationsAsync(id).Result;

            this.ViewBag.Id = movie.Id;
            this.ViewBag.Title = movie.Title;
            this.ViewBag.ImageUrl = "http://image.tmdb.org/t/p/original" + movie.PosterPath;
            this.ViewBag.Rating = movie.VoteAverage;
            this.ViewBag.Description = movie.Overview;
            this.ViewBag.ReleaseDate = movie.ReleaseDate;

            this.ViewBag.Recommendations = recommendations;

            return this.View();
        }
    }
}