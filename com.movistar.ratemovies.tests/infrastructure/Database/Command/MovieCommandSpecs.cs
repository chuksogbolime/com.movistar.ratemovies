using System;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.infrastructure.Database;
using com.movistar.ratemovies.infrastructure.Database.Commands;
using Xunit;
using Shouldly;

namespace com.movistar.ratemovies.tests.infrastructure.Database.Command
{
    public class MovieCommandSpecs
    {
        RateMovieDbContext dbContextMock = DbContextProvider.InitContextWithInMemoryDbSupport();
        IMovieCommand sut;

        public MovieCommandSpecs()
        {
            sut = new MovieCommand(dbContextMock);
        }

        [Fact]
        public async Task AddAsync_Should_Save_Movie_Object_To_DB()
        {
            Movie movie = core.Entities.GenerateData.InitMovie();

            var result = await sut.AddAsync(movie, new System.Threading.CancellationToken());

            result.Flag.ShouldBeTrue();
            result.Message.ShouldBe($"Movie with Id: {movie.Id} saved successfully.");
        }

        [Fact]
        public async Task AddAsync_Should_Throw_An_Error_And_Return_False()
        {
            dbContextMock = DbContextProvider.InitEmptyContext();
            sut = new MovieCommand(dbContextMock);
            Movie movie = core.Entities.GenerateData.InitMovie();

            var result = await sut.AddAsync(movie, new System.Threading.CancellationToken());

            result.Flag.ShouldBeFalse();
            result.Message.ShouldNotBeNullOrEmpty();
        }
    }
}
