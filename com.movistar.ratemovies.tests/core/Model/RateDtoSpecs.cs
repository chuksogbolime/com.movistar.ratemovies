using System;
using com.movistar.ratemovies.core.Model;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.core.Model
{
    public class RateDtoSpecs
    {
        [Fact]
        public void ShouldReturnValidSetValues()
        {
            RateDto expected = GenerateData.InitRateDto();
            expected.CreatedDate.ShouldBe(new DateTime(2021, 6, 2));
            expected.MovieId.ShouldBe("5fcba07c30e3af4497f5de17");
            expected.Comment.ShouldBe("Comments");
            expected.Id.ShouldBe(1);
            expected.Rating.ShouldBe(3);
        }
    }
}
