using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class CulinaryChannel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }

        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
