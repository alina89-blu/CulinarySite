using Database;
using ServiceLayer.ViewModels.RecipeIngredient;
using System;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
{
    public class RecipeDetailModel
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public int DishId { get; set; }
        public int AuthorId { get; set; }
        public int? BookId { get; set; }
        public List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();
    }
}
