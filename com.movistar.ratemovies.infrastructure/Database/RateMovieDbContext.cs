using System;
using System.Reflection;
using com.movistar.ratemovies.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace com.movistar.ratemovies.infrastructure.Database
{
    public class RateMovieDbContext : DbContext
    {
        public RateMovieDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
