using System.Collections.Generic;

namespace Database
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
