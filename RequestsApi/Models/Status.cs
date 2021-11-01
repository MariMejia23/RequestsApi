using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
