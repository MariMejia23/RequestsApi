using RequestsApi.Interfaces;
using RequestsApi.Models;
using RequestsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Services
{
    public class RequestService : IRequestService
    {
        #region Attributes
        readonly UnitOfWork Work;
        #endregion

        #region Constructor
        public RequestService(RequestsDbContext context)
        {
            Work = new UnitOfWork(context);
        }
        #endregion

        #region Public Methods
        public async Task<Request> GetByRequestIdAsync(int id)
        {
            try
            {
                var result = await Work.RequestRepository.FirstByIdAsync(id);
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task CreateAsync(Request request)
        {
            try
            {
                request.CreatedAt = DateTime.Now;
                Work.RequestRepository.Create(request);
                await Work.CommitASync();

            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<Request> GetAll()
        {

            try
            {
                var result = Work.RequestRepository.All();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task UpdateAsync(Request request)
        {

            try
            {
                var exists = await Work.RequestRepository.FirstByIdAsync(request.Id);

                if (exists != null)
                {
                    Work.RequestRepository.Modify(request);
                    await Work.CommitASync();
                }
            }
            catch (Exception ex)
            {
            }

        }
        public async Task DeleteAsync(int id)
        {

            try
            {
                var exists = await Work.RequestRepository.FirstByIdAsync(id);

                if (exists != null)
                {
                    Work.RequestRepository.Delete(exists);
                    await Work.CommitASync();
                }

            }
            catch (Exception ex)
            {
            }

        }
    }
    #endregion
}
