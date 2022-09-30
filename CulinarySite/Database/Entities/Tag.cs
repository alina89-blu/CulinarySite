using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
