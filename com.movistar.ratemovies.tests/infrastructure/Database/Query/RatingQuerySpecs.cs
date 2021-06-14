using System;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Query;
using com.movistar.ratemovies.infrastructure.Database;
using com.movistar.ratemovies.infrastructure.Database.Query;
using Xunit;
using Shouldly;
using System.Linq;

namespace com.movistar.ratemovies.tests.infrastructure.Database.Query
{
    public class RatingQuerySpecs
    {
        RateMovieDbContext dbContextMock = DbContextProvider.InitContextWithInMemoryDbSupport();
        IRatingQuery sut;
        Rating rating = core.Entities.GenerateData.InitRating();
        public RatingQuerySpecs()
        {
            sut = new RatingQuery(dbContextMock);
        }
        private void SeedDb()
        {
            
            dbContextMock.Ratings.Add(rating);
            dbContextMock.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsync_Should_Retrieve_All_Saved_Ratings_Successfully()
        {
            SeedDb();

            var result = await sut.GetAllAsync();
            result.Flag.ShouldBeTrue();
            result.Data.ShouldNotBeNull();
            result.Data.Count().ShouldBeGreaterThan(0);
            result.Message.ShouldBe("Ratings retrieved successfully");
            result.Data.FirstOrDefault().Movie.ShouldNotBeNull();
            result.Data.FirstOrDefault().Movie.Id.ShouldBe(rating.Movie.Id);

        }
        [Fact]
        public async Task GetAllAsync_Should_Retrieve_No_Ratings_When_Db_Is_Empty()
        {
            

            var result = await sut.GetAllAsync();
            result.Flag.ShouldBeFalse();
            result.Data.ShouldBeNull();
            result.Message.ShouldBe("No rating found");

        }

        [Fact]
        public async Task GetAllAsync_Should_Throw_Error_On_Db_Failure()
        {
            dbContextMock = DbContextProvider.InitEmptyContext();
            sut = new RatingQuery(dbContextMock);

            var result = await sut.GetAllAsync();
            result.Flag.ShouldBeFalse();
            result.Data.ShouldBeNull();

        }
    }
}
