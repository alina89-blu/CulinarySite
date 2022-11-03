using CulinarySite.Common.Dtos.Recipe;
using System.Collections.Generic;

namespace CulinarySite.Common.Dtos.Dish
{
    public class DishDetailDto
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        public List<DishRecipeDto> Recipes { get; set; }
        public string ImageUrl { get; set; }
    }
}
