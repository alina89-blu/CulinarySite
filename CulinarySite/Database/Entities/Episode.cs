using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Episode : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int CulinaryChannelId { get; set; }
        public CulinaryChannel CulinaryChannel { get; set; }
        public Image Image { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
