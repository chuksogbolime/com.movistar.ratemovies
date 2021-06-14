using System;
using System.Threading;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Interface.Database.Command;


namespace com.movistar.ratemovies.infrastructure.Database.Commands
{
    public class MovieCommand :IMovieCommand
    {
        private readonly RateMovieDbContext dbContext;

        public MovieCommand(RateMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<(bool Flag, string Message)> AddAsync(Movie entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                dbContext.Movies.Add(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
                return (true, $"Movie with Id: {entity.Id} saved successfully.");
            }
            catch(Exception ex)
            {
                return (false, ex.ToString());
            }
            
        }
    }
}
