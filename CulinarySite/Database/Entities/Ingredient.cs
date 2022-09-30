
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Ingredient : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
      
    }
}
