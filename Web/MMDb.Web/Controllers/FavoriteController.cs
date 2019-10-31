using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMDb.Data.Models;
using MMDb.Web.Services.Contracts;
using MMDb.Web.ViewModels.Favorites;
using MMDb.Web.ViewModels.Movies;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace MMDb.Web.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService favoritesService;
        private readonly IMapper mapper;

        public FavoriteController(IFavoriteService favoritesService, IMapper mapper)
        {
            this.favoritesService = favoritesService;
            this.mapper = mapper;
        }

        public IActionResult Add(int id)
        {
            this.favoritesService.Add(id, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            IEnumerable<FavoriteMovie> userFavoriteMovies = this.favoritesService.All(this.User.Identity.Name);

            var favoriteMoviesVM = this.mapper.Map<IList<FavoriteMovieViewModel>>(userFavoriteMovies);

            return this.View(favoriteMoviesVM);
        }

        public IActionResult Remove(int id)
        {
            this.favoritesService.Remove(id, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}