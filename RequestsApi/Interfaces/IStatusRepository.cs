using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> All();
        Task<Status> FirstByIdAsync(int id);
        void Create(Status status);
        void Modify(Status status);
        void Delete(Status status);
    }
}
