using System;
using com.movistar.ratemovies.core.Model;
using Xunit;
using Shouldly;
using System.Linq;

namespace com.movistar.ratemovies.tests.core.Model
{
    public class MovieDtoSpecs
    {

        [Fact]
        public void ShouldReturnValidSetValues()
        {
            MovieDto expected = GenerateData.InitMovieDto();
            expected.CreatedDate.ShouldBe(new DateTime(2021, 6, 2));
            expected.Id.ShouldBe("5fcba07c30e3af4497f5de17");
            expected.Title.ShouldBe("Test Title");
            expected.ModifiedDate.ShouldBeNull();

            expected.ModifiedDate = new DateTime(2021, 6, 2);
            expected.ModifiedDate.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRate()
        {
            int[] ratings = new int[] { 1, 3, 3, 4, 5, 4, 3, 1, 2, 2 };
            double totalRatings = ratings.Average();
            //int rate = totalRatings/ ratings.Count);
        }
    }
}
