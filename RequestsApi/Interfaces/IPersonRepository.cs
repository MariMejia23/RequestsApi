using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> All();
        Task<Person> FirstByIdAsync(int id);
        void Create(Person person);
        void Modify(Person person);
        void Delete(Person person);
    }
}
