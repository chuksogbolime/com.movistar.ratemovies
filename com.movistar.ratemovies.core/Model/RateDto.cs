using System;
namespace com.movistar.ratemovies.core.Model
{
    public class RateDto
    {
        public long Id { get; set; }
        public string MovieId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
