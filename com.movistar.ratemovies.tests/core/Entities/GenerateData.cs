using System;
using System.Collections.Generic;
using com.movistar.ratemovies.core.Entities;

namespace com.movistar.ratemovies.tests.core.Entities
{
    public class GenerateData
    {
        public static Movie InitMovie() => new Movie
        {
            CreatedDate = new DateTime(2021, 6, 2),
            Id = "5fcba07c30e3af4497f5de17",
            ModifiedDate = null,
            Title = "Test Title"
        };

        public static Rate InitRate() => new Rate
        {
            Comment = "Comments",
            CreatedDate = new DateTime(2021, 6, 2),
            Id = 1,
            MovieId = "5fcba07c30e3af4497f5de17",
            Rating = 3,
            Movie = new Movie()
        };
    }
}
