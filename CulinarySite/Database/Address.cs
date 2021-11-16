using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
