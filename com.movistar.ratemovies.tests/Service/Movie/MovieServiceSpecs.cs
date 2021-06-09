using System;
using System.Threading.Tasks;
using AutoMapper;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Interface.Services;
using com.movistar.ratemovies.core.Model;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.Service.Mappings;
using com.movistar.ratemovies.Service.Movie;
using Moq;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.Service.Movie
{
    public class MovieServiceSpecs
    {

        IMovieService sut;
        Mock<IMovieCommand> commandMock = new Mock<IMovieCommand>();

        MapperConfiguration mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MovieMapProfile());
        });

        [Fact]
        public async Task AddAsync_Should_Save_Movie_Successfully()
        {
            MovieDto movie = core.Model.GenerateData.InitMovieDto();
            commandMock.Setup(p => p.AddAsync(It.IsAny< ratemovies.core.Entities.Movie>(), It.IsAny<System.Threading.CancellationToken>()))
                .ReturnsAsync(() => (true, "Successful"));
            sut = new MovieService(commandMock.Object, mapper.CreateMapper());
            
            var result = await sut.AddAsync(movie, new System.Threading.CancellationToken());

            result.Flag.ShouldBeTrue();
            result.Message.ShouldNotBeNullOrEmpty();
        }
    }
}
