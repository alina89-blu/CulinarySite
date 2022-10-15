
using System;

namespace CulinarySite.Common.ViewModels.Recipe
{
    public class CreateUpdateRecipeBaseModel
    {
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public int DishId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public string ImageUrl { get; set; }


    }
}
