using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Query;
using Microsoft.EntityFrameworkCore;

namespace com.movistar.ratemovies.infrastructure.Database.Query
{
    public class RatingQuery : IRatingQuery
    {
        private readonly RateMovieDbContext dbContext;

        public RatingQuery(RateMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<(bool Flag, IEnumerable<Rating> Data, string Message)> GetAllAsync()
        {
            try
            {
                var result = await dbContext.Ratings.Include(O => O.Movie).ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Ratings retrieved successfully");
                else
                    return (false, null, "No rating found");

            }
            catch (Exception ex)
            {
                return (false, null, ex.ToString());
            }
        }
    }
}
