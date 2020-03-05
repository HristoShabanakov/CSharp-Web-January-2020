using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lekarna.Models
{
    public class Pharmacy
    {
        public string Id { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; } 
    }
}
