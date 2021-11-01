using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
        Task<Status> GetByStatusIdAsync(int id);
        Task CreateAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(int id);
    }
}
