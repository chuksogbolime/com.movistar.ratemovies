using System;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Command;
using com.movistar.ratemovies.infrastructure.Database;
using com.movistar.ratemovies.infrastructure.Database.Commands;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.infrastructure.Database.Command
{
    public class RateCommandSpecs
    {
        RateMovieDbContext dbContextMock = DbContextProvider.InitContextWithInMemoryDbSupport();
        IRatingCommand sut;

        public RateCommandSpecs()
        {
            sut = new RatingCommand(dbContextMock);
        }

        [Fact]
        public async Task AddAsync_Should_Save_Rate_Object_To_DB()
        {
            Rating rate = core.Entities.GenerateData.InitRating();

            var result = await sut.AddAsync(rate, new System.Threading.CancellationToken());

            result.Flag.ShouldBeTrue();
            result.Message.ShouldBe($"Rating with Id: {rate.Id} saved successfully.");
        }

        [Fact]
        public async Task AddAsync_Should_Throw_An_Error_And_Return_False()
        {
            dbContextMock = DbContextProvider.InitEmptyContext();
            sut = new RatingCommand(dbContextMock);
            Rating rate = core.Entities.GenerateData.InitRating();

            var result = await sut.AddAsync(rate, new System.Threading.CancellationToken());

            result.Flag.ShouldBeFalse();
            result.Message.ShouldNotBeNullOrEmpty();
        }
    }
}
