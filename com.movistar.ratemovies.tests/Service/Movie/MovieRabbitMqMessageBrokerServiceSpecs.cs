using System;
using System.Threading.Tasks;
using AutoMapper;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.core.Interface.MessageBroker;
using com.movistar.ratemovies.core.Model;
using com.movistar.ratemovies.Service.Mappings;
using com.movistar.ratemovies.Service.Movie;
using Moq;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.Service.Movie
{
    public class MovieRabbitMqMessageBrokerServiceSpecs
    {
        IRabbitMqMessageBrokerService<MovieDto> sut;
        Mock<IMovieCommand> commandMock = new Mock<IMovieCommand>();
        MapperConfiguration mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MovieMapProfile());
        });

        public MovieRabbitMqMessageBrokerServiceSpecs()
        {
            sut = new MovieRabbitMqMessageBrokerService(commandMock.Object, mapper.CreateMapper());
        }

        [Fact]
        public async Task Should_Handle_Message_Of_Type_MovieDto_Successfully()
        {
            MovieDto movie = core.Model.GenerateData.InitMovieDto();
            commandMock.Setup(p => p.AddAsync(It.IsAny<ratemovies.core.Entities.Movie>(), It.IsAny<System.Threading.CancellationToken>()))
                .ReturnsAsync(() => (true, "Successful"));

            var result = await sut.HandleMessageAsync(movie, new System.Threading.CancellationToken());
            
            result.ShouldBeTrue();
        }
    }
}
