using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
