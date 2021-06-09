using System;
using com.movistar.ratemovies.infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace com.movistar.ratemovies.tests.infrastructure.Database
{
    public static class DbContextProvider
    {
        public static RateMovieDbContext InitContextWithInMemoryDbSupport()
        {
            var options = new DbContextOptionsBuilder<RateMovieDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var _dbContext = new RateMovieDbContext(options);
            _dbContext.Database.EnsureCreated();

            return _dbContext;
        }

        public static RateMovieDbContext InitEmptyContext() => null;
    }
}
