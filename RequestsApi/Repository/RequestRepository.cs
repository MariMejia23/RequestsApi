using Microsoft.EntityFrameworkCore;
using RequestsApi.Interfaces;
using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context) { }

        public IEnumerable<Request> All()
        {
            var result = this.GetAll().Include("Person").Include("Status");
            return result;
        }
        public async Task<Request> FirstByIdAsync(int id)
        {
            var result = await this.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public void Create(Request request)
        {
            this.Add(request);
        }

        public void Modify(Request request)
        {
            this.Update(request);
        }

        public void Delete(Request request)
        {
            this.Remove(request);
        }
    }
}
