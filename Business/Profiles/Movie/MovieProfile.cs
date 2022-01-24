using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieVm>()
                  .ForMember(dest => dest.CategoryName,
                    act => act.MapFrom(src => src.Category.CategoryName));
            CreateMap<MovieVm, Movie>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MoviePutDto>();
            CreateMap<MoviePutDto, Movie>();
        }
    }
}
