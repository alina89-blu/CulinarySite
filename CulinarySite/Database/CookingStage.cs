using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CookingStage : BaseEntity
    {
        public string Content { get; set; }

        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
