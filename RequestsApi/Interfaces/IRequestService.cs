using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAll();
        Task<Request> GetByRequestIdAsync(int id);
        Task CreateAsync(Request request);
        Task UpdateAsync(Request request);
        Task DeleteAsync(int id);
    }
}
