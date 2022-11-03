using CulinarySite.Common.ViewModels.Recipe;
using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Dish
{
    public class DishDetailModel
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        public List<DishRecipeModel> Recipes { get; set; }
        public string ImageUrl { get; set; }
    }
}
