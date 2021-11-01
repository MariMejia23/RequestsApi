using RequestsApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class UnitOfWork
    {
        private readonly RequestsDbContext _context;

        public UnitOfWork(RequestsDbContext context)
        {
            _context = context;
        }

        private IPersonRepository personRepository;
        public IPersonRepository PersonRepository
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(_context);

                return personRepository;
            }
        }
        private IRequestRepository requestRepository;
        public IRequestRepository RequestRepository
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(_context);

                return requestRepository;
            }
        }
        private IStatusRepository statusRepository;
        public IStatusRepository StatusRepository
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(_context);

                return statusRepository;
            }
        }
        public async Task<int> CommitASync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
