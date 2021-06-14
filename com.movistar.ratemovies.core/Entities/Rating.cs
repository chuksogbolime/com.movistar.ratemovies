using System;
using System.Collections;

namespace com.movistar.ratemovies.core.Entities
{
    public class Rating
    {
        public long Id { get; set; }
        public string MovieId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }

        public Movie Movie { get; set; }
    }
}
