using System;
using AutoMapper;
using com.movistar.ratemovies.core.Model;
using Xunit;

namespace com.movistar.ratemovies.tests.Service.Mappings
{
    public class MapProfileSpecs
    {
        IConfigurationProvider config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
        });
        private readonly IMapper mapper;

        public MapProfileSpecs()
        {
            mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_Profile_Should_Create_Valid_Configurations()
        {
           
            config.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(ratemovies.core.Entities.Movie), typeof(MovieDto))]
        [InlineData(typeof(MovieDto), typeof(ratemovies.core.Entities.Movie))]
        [InlineData(typeof(ratemovies.core.Entities.Rate), typeof(RateDto))]
        [InlineData(typeof(RateDto), typeof(ratemovies.core.Entities.Rate))]
        public void Map_From_Source_To_Destination_Should_Be_Valid(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            mapper.Map(instance, source, destination);
        }
    }
}
