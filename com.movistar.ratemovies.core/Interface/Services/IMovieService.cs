using System;
using System.Threading;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Model;

namespace com.movistar.ratemovies.core.Interface.Services
{
    public interface IMovieService
    {
        Task<(bool Flag, string Message)> AddAsync(MovieDto movie, CancellationToken cancellationToken);
    }
}
