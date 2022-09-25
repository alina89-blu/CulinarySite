
using ServiceLayer.Dtos.Recipe;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IRecipeService
    {
        void CreateRecipe(CreateRecipeDto createRecipeDto);
        void UpdateRecipe(UpdateRecipeDto updateRecipeDto);
        void DeleteRecipe(int id);
        IEnumerable<RecipeListDto> GetRecipeList(bool withRelated);
        RecipeDetailDto GetRecipe(int id, bool withRelated);
    }
}
