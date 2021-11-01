using RequestsApi.Interfaces;
using RequestsApi.Models;
using RequestsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Services
{
    public class StatusService : IStatusService
    {
        #region Attributes
        readonly UnitOfWork Work;
        #endregion

        #region Constructor
        public StatusService(RequestsDbContext context)
        {
            Work = new UnitOfWork(context);
        }
        #endregion

        #region Public Methods
        public async Task<Status> GetByStatusIdAsync(int id)
        {
            try
            {
                var result = await Work.StatusRepository.FirstByIdAsync(id);
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task CreateAsync(Status status)
        {
            try
            {
                Work.StatusRepository.Create(status);
                await Work.CommitASync();

            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<Status> GetAll()
        {

            try
            {
                var result = Work.StatusRepository.All();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task UpdateAsync(Status status)
        {

            try
            {
                var exists = await Work.StatusRepository.FirstByIdAsync(status.Id);

                if (exists != null)
                {
                    Work.StatusRepository.Modify(status);
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
                var exists = await Work.StatusRepository.FirstByIdAsync(id);

                if (exists != null)
                {
                    Work.StatusRepository.Delete(exists);
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
