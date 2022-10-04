using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

    }
}
