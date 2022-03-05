using Database;
using System.Collections.Generic;
using ServiceLayer.ViewModels.RecipeIngredient;

namespace ServiceLayer
{
    public interface IRecipeIngredientService
    {
        void CreateRecipeIngredient(CreateRecipeIngredientModel createRecipeIngredientModel);
        void UpdateRecipeIngredient(UpdateRecipeIngredientModel updateRecipeIngredientModel);
        void DeleteRecipeIngredient(int id);
        IEnumerable<RecipeIngredientListModel> GetRecipeIngredientList(bool withRelated);
        RecipeIngredientDetailModel GetRecipeIngredient(int id, bool withRelated);
    }
}
