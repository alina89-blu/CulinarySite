
using System.Collections.Generic;

namespace Database
{
    public class RecipeIngredient : BaseEntity
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
      
    }
}
