using System;
using com.movistar.ratemovies.core.Entities;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.core.Entities
{
    public class RateSpecs
    {
        [Fact]
        public void ShouldReturnValidSetValues()
        {
            Rating expected = GenerateData.InitRating();
            expected.CreatedDate.ShouldBe(new DateTime(2021, 6, 2));
            expected.MovieId.ShouldBe("5fcba07c30e3af4497f5de17");
            expected.Comment.ShouldBe("Comments");
            expected.Id.ShouldBe(1);
            expected.Score.ShouldBe(3);
            expected.Movie.ShouldNotBeNull();
        }
    }
}
