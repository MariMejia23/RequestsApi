using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> All();
        Task<Request> FirstByIdAsync(int id);
        void Create(Request request);
        void Modify(Request request);
        void Delete(Request request);
    }
}
