using Microsoft.EntityFrameworkCore;
using RequestsApi.Interfaces;
using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(DbContext context) : base(context) { }

        public IEnumerable<Status> All()
        {
            var result = this.GetAll();
            return result;
        }
        public async Task<Status> FirstByIdAsync(int id)
        {
            var result = await this.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public void Create(Status status)
        {
            this.Add(status);
        }

        public void Modify(Status status)
        {
            this.Update(status);
        }

        public void Delete(Status status)
        {
            this.Remove(status);
        }
    }
}
