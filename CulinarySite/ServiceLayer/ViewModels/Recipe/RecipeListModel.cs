using System;
using System.Collections.Generic;
using ServiceLayer.ViewModels.RecipeIngredient;

namespace ServiceLayer.ViewModels.Recipe
{
    public class RecipeListModel
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public string DishCategory { get; set; }
        public string AuthorName { get; set; }
        public string? BookName { get; set; }
        public List<RecipeIngredientModel> RecipeIngredients { get; set; } = new List<RecipeIngredientModel>();
    }
}
