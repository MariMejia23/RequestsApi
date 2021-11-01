using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
