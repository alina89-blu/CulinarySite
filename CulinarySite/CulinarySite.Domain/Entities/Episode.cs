using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Episode : BaseEntity
    {    
        public string Name { get; set; }
        public int CulinaryChannelId { get; set; }
        public CulinaryChannel CulinaryChannel { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

       
    }
}
