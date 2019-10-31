using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MMDb.Data.Models;
using MMDb.Web.Services.Contracts;
using MMDb.Web.ViewModels.Lists;

namespace MMDb.Web.Controllers
{
    [Route("Lists")]
    public class ListsController : Controller
    {
        private readonly IlistService listService;
        private readonly IMapper mapper;

        public ListsController(IlistService listService, IMapper mapper)
        {
            this.listService = listService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var lists = this.listService.GetAllMovieLists(this.User.Identity.Name);

            var model = this.mapper.Map<IList<MovieListViewModel>>(lists);

            return this.View(model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateMovieListViewModel vm)
        {
            var list = this.mapper.Map<MovieList>(vm);

            this.listService.Create(list, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}