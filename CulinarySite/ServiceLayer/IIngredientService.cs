using System.Collections.Generic;
using ServiceLayer.ViewModels.Ingredient;

namespace ServiceLayer
{
    public interface IIngredientService
    {
        void CreateIngredient(CreateIngredientModel createIngredientModel);
        void UpdateIngredient(UpdateIngredientModel updateIngredientModel);
        void DeleteIngredient(int id);
        IEnumerable<IngredientListModel> GetIngredientList(bool withRelated);
        IngredientDetailModel GetIngredient(int id, bool withRelated);
    }
}
