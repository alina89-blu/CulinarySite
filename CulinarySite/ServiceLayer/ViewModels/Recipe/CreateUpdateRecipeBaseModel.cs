using ServiceLayer.ViewModels.RecipeIngredient;
using ServiceLayer.ViewModels.RecipeOrganicMatter;
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
        public int? BookId { get; set; }       
        public List<CreateRecipeIngredientModel> RecipeIngredients { get; set; } = new List<CreateRecipeIngredientModel>();
        public List<CreateRecipeOrganicMatterModel> OrganicMatterRecipes { get; set; } = new List<CreateRecipeOrganicMatterModel>();
    }
}
