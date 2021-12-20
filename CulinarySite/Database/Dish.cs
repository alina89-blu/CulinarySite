using System.Collections.Generic;

namespace Database
{
    public class Dish : BaseEntity
    {
        public DishCategory Category { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Image Image { get; set; }
    }
}
