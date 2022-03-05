using System.Collections.Generic;

namespace Database
{
    public class RecipeOrganicMatter : BaseEntity
    {
        public int OrganicMatterId { get; set; }
        public OrganicMatter OrganicMatter { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
