using System;
using AutoMapper;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.Service.Mappings
{
    public class MovieMapProfile : Profile
    {
        public MovieMapProfile()
        {
            CreateMap<core.Entities.Movie, MovieDto>().ReverseMap();
        }
    }
}
