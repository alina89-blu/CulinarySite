using System.Collections.Generic;

namespace Database
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}

