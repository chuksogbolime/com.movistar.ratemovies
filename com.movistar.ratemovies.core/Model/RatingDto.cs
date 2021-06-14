using System;
namespace com.movistar.ratemovies.core.Model
{
    public class RatingDto
    {
        public long Id { get; set; }
        public string MovieId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
