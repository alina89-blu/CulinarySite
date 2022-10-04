using CulinarySite.Common.Dtos.Recipe;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
