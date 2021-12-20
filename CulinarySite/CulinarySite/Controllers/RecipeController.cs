using System.Collections.Generic;
using Database;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class RecipeController:BaseController
    {
       private readonly IRecipeService recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetRecipeListWithInclude()
        {
            return this.recipeService.GetRecipeListWithInclude();
        }

        [HttpGet("{id}")]
        public Recipe GetRecipeWithInclude(int id)
        {
            return this.recipeService.GetRecipeWithInclude(id);
        }

        [HttpPost]
        public void CreateRecipe(Recipe recipe)
        {
            this.recipeService.CreateRecipe(recipe);
        }

        [HttpPut]
        public void UpdateRecipe(Recipe recipe)
        {
            this.recipeService.UpdateRecipe(recipe);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            this.recipeService.DeleteRecipe(id);
        }
    }
}
