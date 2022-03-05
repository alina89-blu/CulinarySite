using System.Collections.Generic;

namespace Database
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public int DishId { get; set; }
     //   public int? DishId { get; set; } SQL SERVER ? CASCADE
        public Dish Dish { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int? CookingStageId { get; set; }
        public CookingStage CookingStage { get; set; }
    }
}
