
using ServiceLayer.Dtos.Recipe;
using System.Collections.Generic;

namespace ServiceLayer.Dtos.Dish
{
    public class DishDetailDto
    {
        public int DishId { get; set; }
        public string Category { get; set; }
      //  public List<RecipeDto> Recipes { get; set; }
        public List<RecipeDetailDto> Recipes { get; set; }
    }
}
