﻿using AutoMapper;
using MMDb.Data.Models;
using MMDb.Web.ViewModels.Favorites;
using MMDb.Web.ViewModels.Lists;
using MMDb.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMDb.Web.Mapping
{
    public class MMDbConfig : Profile
    {
        public MMDbConfig()
        {
            this.CreateMap<CreateMovieListViewModel, MovieList>();
            this.CreateMap<EditMovieListViewModel, MovieList>();
            this.CreateMap<MovieList, EditMovieListViewModel>();
            this.CreateMap<MovieList, MovieListViewModel>();

            this.CreateMap<FavoriteMovie, FavoriteMovieViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Movie.ImageUrl))
                .ForMember(x => x.MovieNmr, y => y.MapFrom(src => src.Movie.MovieNmr))
                .ForMember(x => x.Rating, y => y.MapFrom(src => src.Movie.Rating))
                .ForMember(x => x.Title, y => y.MapFrom(src => src.Movie.Title))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(src => src.Movie.ReleaseDate))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Movie.Description))
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Movie.Id));
        }
    }
}
