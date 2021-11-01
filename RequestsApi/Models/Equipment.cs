using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
