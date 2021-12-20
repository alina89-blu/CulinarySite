using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface IIngredientService
    {
        void CreateIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        void DeleteIngredient(int id);
        IEnumerable<Ingredient> GetIngredientListWithInclude();
        Ingredient GetIngredientWithInclude(int id);
    }
}
