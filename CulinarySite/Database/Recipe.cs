using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public string Content { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<OrganicMatter> OrganicMatters { get; set; } = new List<OrganicMatter>();
        public List<CookingStage> CookingStages { get; set; } = new List<CookingStage>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
