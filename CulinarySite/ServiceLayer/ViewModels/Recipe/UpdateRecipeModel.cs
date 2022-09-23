﻿

using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using ServiceLayer.ViewModels.Tag;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
{
    public class UpdateRecipeModel : CreateUpdateRecipeBaseModel
    {
        public int RecipeId { get; set; }
        public List<UpdateIngredientModel> Ingredients { get; set; } = new List<UpdateIngredientModel>();
        public List<UpdateOrganicMatterModel> OrganicMatters { get; set; } = new List<UpdateOrganicMatterModel>();
        public List<UpdateCookingStageModel> CookingStages { get; set; } = new List<UpdateCookingStageModel>();
        public List<UpdateTagModel> Tags { get; set; } = new List<UpdateTagModel>();

    }
}
