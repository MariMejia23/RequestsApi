using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Task<Person> GetByPersonIdAsync(int id);
        Task CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id);
    }
}
