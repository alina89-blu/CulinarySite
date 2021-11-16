using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}
