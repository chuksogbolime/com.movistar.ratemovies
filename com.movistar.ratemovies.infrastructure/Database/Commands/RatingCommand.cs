using System;
using System.Threading;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Command;

namespace com.movistar.ratemovies.infrastructure.Database.Commands
{
    public class RatingCommand : IRatingCommand
    {
        private readonly RateMovieDbContext dbContext;

        public RatingCommand(RateMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<(bool Flag, string Message)> AddAsync(Rating entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                dbContext.Ratings.Add(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
                return (true, $"Rating with Id: {entity.Id} saved successfully.");
            }
            catch (Exception ex)
            {
                return (false, ex.ToString());
            }
        }
    }
}
