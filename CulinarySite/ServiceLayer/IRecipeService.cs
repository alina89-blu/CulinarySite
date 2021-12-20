using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IRecipeService
    {
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
        IEnumerable<Recipe> GetRecipeListWithInclude();
        Recipe GetRecipeWithInclude(int id);
    }
}
