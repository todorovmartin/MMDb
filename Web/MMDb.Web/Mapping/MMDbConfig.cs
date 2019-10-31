using AutoMapper;
<<<<<<< HEAD
using MMDb.Data.Models;
using MMDb.Web.ViewModels.Favorites;
=======
>>>>>>> 04617f2c5c0b150e5807d9f762cf2631c36a95e9
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
            //this.CreateMap<Movie, MovieViewModel>();
<<<<<<< HEAD
            this.CreateMap<FavoriteMovie, FavoriteMovieViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Movie.ImageUrl))
                .ForMember(x => x.MovieNmr, y => y.MapFrom(src => src.Movie.MovieNmr))
                .ForMember(x => x.Rating, y => y.MapFrom(src => src.Movie.Rating))
                .ForMember(x => x.Title, y => y.MapFrom(src => src.Movie.Title))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(src => src.Movie.ReleaseDate))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Movie.Description))
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Movie.Id));
=======
>>>>>>> 04617f2c5c0b150e5807d9f762cf2631c36a95e9
        }
    }
}
