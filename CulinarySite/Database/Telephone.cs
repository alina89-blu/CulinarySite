using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Telephone : BaseEntity
    {
        public string Number { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
