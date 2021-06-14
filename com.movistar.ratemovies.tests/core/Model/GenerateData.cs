using System;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.tests.core.Model
{
    public class GenerateData
    {
        public static MovieDto InitMovieDto() => new MovieDto
        {
            CreatedDate = new DateTime(2021,6,2),
            Id = "5fcba07c30e3af4497f5de17",
            ModifiedDate = null,
            Title = "Test Title"
        };

        public static RatingDto InitRatingDto() => new RatingDto
        {
            Comment = "Comments",
            CreatedDate = new DateTime(2021, 6, 2),
            Id = 1,
            MovieId = "5fcba07c30e3af4497f5de17",
            Score = 3
        };
    }
}
