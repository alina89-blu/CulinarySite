using Database;
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.Tag;
using System;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Image.RecipeImage;

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
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();        
        public List<OrganicMatterModel> OrganicMatters { get; set; } = new List<OrganicMatterModel>();
        public List<CookingStageModel> CookingStages { get; set; } = new List<CookingStageModel>();
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
        public RecipeImageModel Image { get; set; }
    }
}
