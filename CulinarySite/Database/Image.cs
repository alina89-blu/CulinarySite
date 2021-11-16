using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public int? DishId { get; set; }
        public Dish Dish { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int? CookingStageId { get; set; }
        public CookingStage CookingStage { get; set; }
    }
}
