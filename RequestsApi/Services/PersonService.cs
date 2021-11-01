using RequestsApi.Interfaces;
using RequestsApi.Models;
using RequestsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Services
{
    public class PersonService: IPersonService
    {
        #region Attributes
        readonly UnitOfWork Work;
        #endregion

        #region Constructor
        public PersonService(RequestsDbContext context)
        {
            Work = new UnitOfWork(context);
        }
        #endregion

        #region Public Methods
        public async Task<Person> GetByPersonIdAsync(int id)
        {       
            try
            {
                var result = await Work.PersonRepository.FirstByIdAsync(id);
                return result;
               
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task CreateAsync(Person person)
        {      
            try
            {
                Work.PersonRepository.Create(person);
                await Work.CommitASync();

            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<Person> GetAll()
        {          

            try
            {
                var result = Work.PersonRepository.All();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task UpdateAsync(Person person)
        {

            try
            {
                var exists = await Work.PersonRepository.FirstByIdAsync(person.Id);

                if (exists != null)
                {
                    Work.PersonRepository.Modify(person);
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
                var exists = await Work.PersonRepository.FirstByIdAsync(id);

                if (exists != null)
                {
                    Work.PersonRepository.Delete(exists);
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
