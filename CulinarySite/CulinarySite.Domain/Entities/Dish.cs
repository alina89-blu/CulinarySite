using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Dish : BaseEntity
    {        
        public string Category { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Image Image { get; set; }
    }
}
