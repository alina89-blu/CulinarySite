using CulinarySite.Common.ViewModels.CookingStage;
using CulinarySite.Common.ViewModels.Ingredient;
using CulinarySite.Common.ViewModels.OrganicMatter;
using CulinarySite.Common.ViewModels.Tag;
using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Recipe
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
