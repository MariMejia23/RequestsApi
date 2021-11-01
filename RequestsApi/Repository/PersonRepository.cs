using Microsoft.EntityFrameworkCore;
using RequestsApi.Interfaces;
using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context) { }

        public IEnumerable<Person> All()
        {
            var result = this.GetAll();
            return result;
        }
        public async Task<Person> FirstByIdAsync(int id)
        {
            var result = await this.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }
       
        public void Create(Person person)
        {
            this.Add(person);
        }

        public void Modify(Person person)
        {
            this.Update(person);
        }

        public void Delete(Person person)
        {
            this.Remove(person);
        }
    }
}
