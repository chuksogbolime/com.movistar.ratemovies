using System;
using System.Collections;
using System.Collections.Generic;

namespace com.movistar.ratemovies.core.Entities
{
    public class Movie
    {
        public Movie()
        {
            Ratings = new HashSet<Rating>();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
