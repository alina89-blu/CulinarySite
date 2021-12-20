using System.Collections.Generic;

namespace Database
{
    public class OrganicMatter : BaseEntity
    {
        public OrganicMatterName Name { get; set; }
        public Unit Unit { get; set; }
        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
