using CulinarySite.Common.ViewModels.CookingStage;
using CulinarySite.Common.ViewModels.Ingredient;
using CulinarySite.Common.ViewModels.OrganicMatter;
using CulinarySite.Common.ViewModels.Tag;
using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Recipe
{
    public class CreateRecipeModel : CreateUpdateRecipeBaseModel
    {
        public List<CreateIngredientModel> Ingredients { get; set; } = new List<CreateIngredientModel>();
        public List<CreateOrganicMatterModel> OrganicMatters { get; set; } = new List<CreateOrganicMatterModel>();
        public List<CreateCookingStageModel> CookingStages { get; set; } = new List<CreateCookingStageModel>();//
        public List<CreateTagModel> Tags { get; set; } = new List<CreateTagModel>();

    }
}
