using ServiceLayer.ViewModels.Recipe;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IRecipeService
    {
        void CreateRecipe(CreateRecipeModel createRecipeModel);
        void UpdateRecipe(UpdateRecipeModel updateRecipeModel);
        void DeleteRecipe(int id);
        IEnumerable<RecipeListModel> GetRecipeList(bool withRelated);
        RecipeDetailModel GetRecipe(int id, bool withRelated);
    }
}
