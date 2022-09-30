using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
