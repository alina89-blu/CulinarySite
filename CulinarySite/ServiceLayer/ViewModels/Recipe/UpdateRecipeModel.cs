
using ServiceLayer.ViewModels.RecipeIngredient;
using ServiceLayer.ViewModels.RecipeOrganicMatter;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Recipe
{
    public class UpdateRecipeModel : CreateUpdateRecipeBaseModel
    {
        public int RecipeId { get; set; }
       public List<UpdateRecipeIngredientModel> RecipeIngredients { get; set; } = new List<UpdateRecipeIngredientModel>();
        public List<UpdateRecipeOrganicMatterModel> OrganicMatterRecipes { get; set; } = new List<UpdateRecipeOrganicMatterModel>();
       // public List<CreateRecipeIngredientModel> RecipeIngredients { get; set; } = new List<CreateRecipeIngredientModel>();
    }
}
