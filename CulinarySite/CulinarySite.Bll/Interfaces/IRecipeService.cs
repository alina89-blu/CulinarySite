﻿using CulinarySite.Common.Dtos.Recipe;
using CulinarySite.Common.Pagination;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
{
    public interface IRecipeService
    {
        void CreateRecipe(CreateRecipeDto createRecipeDto);
        void UpdateRecipe(UpdateRecipeDto updateRecipeDto);
        void DeleteRecipe(int id);
        IEnumerable<RecipeListDto> GetRecipeDetailList(bool withRelated);
        IEnumerable<RecipeDto> GetRecipeList();
        RecipeDetailDto GetRecipe(int id, bool withRelated);
        PagedList<RecipeListDto> GetPaginatedRecipes(PagingParameters pagingParameters);

    }
}
