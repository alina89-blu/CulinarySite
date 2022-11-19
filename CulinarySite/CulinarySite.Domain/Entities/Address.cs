using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
