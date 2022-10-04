
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.Tag;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
{
    public class CreateRecipeModel : CreateUpdateRecipeBaseModel
    {
        public List<CreateIngredientModel> Ingredients { get; set; } = new List<CreateIngredientModel>();
        public List<CreateOrganicMatterModel> OrganicMatters { get; set; } = new List<CreateOrganicMatterModel>();
        public List<CreateCookingStageModel> CookingStages { get; set; } = new List<CreateCookingStageModel>();//
        public List<CreateTagModel> Tags { get; set; } = new List<CreateTagModel>();

    }
}
