using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Dish : BaseEntity
    {
        public DishCategory Category { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Image Image { get; set; }
    }
}
