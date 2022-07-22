
using ServiceLayer.ViewModels.RecipeIngredient;
using ServiceLayer.ViewModels.RecipeOrganicMatter;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
{
    public class CreateRecipeModel : CreateUpdateRecipeBaseModel
    {
        public List<CreateRecipeIngredientModel> RecipeIngredients { get; set; } = new List<CreateRecipeIngredientModel>();
        public List<CreateRecipeOrganicMatterModel> OrganicMatterRecipes { get; set; } = new List<CreateRecipeOrganicMatterModel>();
    }
}
