using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Episode : BaseEntity
    {
        public string Name { get; set; }

        public int? CulinaryChannelId { get; set; }
        public CulinaryChannel CulinaryChannel { get; set; }
        public Image Image { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
