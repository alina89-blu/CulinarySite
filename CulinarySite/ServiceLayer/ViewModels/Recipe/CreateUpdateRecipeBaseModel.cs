
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using System;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
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
        

    }
}
