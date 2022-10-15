using CulinarySite.Common.ViewModels.CookingStage;
using CulinarySite.Common.ViewModels.Ingredient;
using CulinarySite.Common.ViewModels.OrganicMatter;
using CulinarySite.Common.ViewModels.Tag;
using System;
using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Recipe
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
        public string BookName { get; set; }
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public List<OrganicMatterModel> OrganicMatters { get; set; } = new List<OrganicMatterModel>();
        public List<CookingStageModel> CookingStages { get; set; } = new List<CookingStageModel>();
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
        public string ImageUrl { get; set; }
    }
}
