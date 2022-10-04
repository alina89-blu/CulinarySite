using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Domain.Entities
{
    public class Image : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public int? DishId { get; set; }    
        public Dish Dish { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int? CookingStageId { get; set; }
        public CookingStage CookingStage { get; set; }
        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
