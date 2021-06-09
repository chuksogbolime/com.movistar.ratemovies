using System;
namespace com.movistar.ratemovies.core.Model
{
    public class MovieDto
    {

       public string Id { get; set; }
       public string Title { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime? ModifiedDate { get; set; }
    }
}
