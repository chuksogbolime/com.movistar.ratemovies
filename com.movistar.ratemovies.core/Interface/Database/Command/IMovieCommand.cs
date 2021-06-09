using System;
using System.Threading;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.core.Interface.Database.Command
{
    public interface IMovieCommand
    {
        Task<(bool Flag, string Message)> AddAsync(Movie movie, CancellationToken cancellationToken);
    }
}
