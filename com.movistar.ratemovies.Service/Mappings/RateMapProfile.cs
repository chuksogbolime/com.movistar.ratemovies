using System;
using AutoMapper;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.Service.Mappings
{
    public class RateMapProfile:Profile
    {
        public RateMapProfile()
        {
            CreateMap<core.Entities.Rating, RatingDto>().ReverseMap();
        }
    }
}
