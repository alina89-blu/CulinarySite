using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Domain.Entities
{
    public class Dish : BaseEntity
    {
        [Required]
        public string Category { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Image Image { get; set; }
    }
}
