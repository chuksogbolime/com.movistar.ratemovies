using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.movistar.ratemovies.core.Entities;

namespace com.movistar.ratemovies.core.Interface.Database.Query
{
    public interface IRatingQuery
    {
        Task<(bool Flag, IEnumerable<Rating> Data, string Message)> GetAllAsync();
    }
}
