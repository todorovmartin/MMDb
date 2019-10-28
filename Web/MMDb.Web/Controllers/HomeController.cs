namespace MMDb.Web.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using MMDb.Web.ViewModels;
    using MMDb.Web.ViewModels.Movies;
    using TMDbLib.Client;
    using TMDbLib.Objects.Search;

    public class HomeController : BaseController
    {
        private int page = 1;

        public IActionResult Index(string searchQuery, int currPage)
        {
            TMDbClient client = new TMDbClient(Environment.GetEnvironmentVariable("TMDB_API_KEY"));
            this.page = currPage;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var results = client.SearchMovieAsync(searchQuery, this.page).Result;

                this.ViewBag.TotalResults = results.TotalResults;
                this.ViewBag.TotalPages = results.TotalPages;
                this.ViewBag.SearchQuery = searchQuery;
                this.ViewBag.CurrentPage = currPage;

                var model = results.Results.Select(x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = "http://image.tmdb.org/t/p/original" + x.PosterPath,
                    Rating = x.VoteAverage,
                    Description = x.Overview,
                    ReleaseDate = x.ReleaseDate,
                });

                return this.View(model);
            }

            return this.View();
        }

        public IActionResult Search(string searchQuery)
        {
            return this.RedirectToAction("Index", new { searchQuery });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
