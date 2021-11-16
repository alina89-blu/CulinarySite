using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
