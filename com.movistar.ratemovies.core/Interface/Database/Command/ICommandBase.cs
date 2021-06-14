using System;
using System.Threading;
using System.Threading.Tasks;

namespace com.movistar.ratemovies.core.Interface.Database.Command
{
    public interface ICommandBase<T>
    {
        Task<(bool Flag, string Message)> AddAsync(T entity, CancellationToken cancellationToken);
    }
}
