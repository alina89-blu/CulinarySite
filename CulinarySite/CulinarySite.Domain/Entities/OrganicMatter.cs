using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class OrganicMatter : BaseEntity
    {        
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
