using System;
using com.movistar.ratemovies.core.Entities;
using Shouldly;
using Xunit;

namespace com.movistar.ratemovies.tests.core.Entities
{
    public class MovieSpecs
    {
        [Fact]
        public void ShouldReturnValidSetValues()
        {
            Movie expected = GenerateData.InitMovie();
            expected.CreatedDate.ShouldBe(new DateTime(2021, 6, 2));
            expected.Id.ShouldBe("5fcba07c30e3af4497f5de17");
            expected.Title.ShouldBe("Test Title");
            expected.ModifiedDate.ShouldBeNull();

            expected.ModifiedDate = new DateTime(2021, 6, 2);
            expected.ModifiedDate.ShouldNotBeNull();
            expected.Ratings.ShouldNotBeNull();
        }
    }
}
