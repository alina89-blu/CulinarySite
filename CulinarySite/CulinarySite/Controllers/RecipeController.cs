using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Recipe;

namespace CulinarySite.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IIngredientService ingredientService;

        public RecipeController(IRecipeService recipeService, IIngredientService ingredientService)
        {
            this.recipeService = recipeService;
            this.ingredientService = ingredientService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RecipeListModel> GetRecipeList(bool withRelated)
        {
            return this.recipeService.GetRecipeList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public RecipeDetailModel GetRecipe(int id, bool withRelated)
        {
            return this.recipeService.GetRecipe(id, withRelated);
        }

        [HttpPost]
        public void CreateRecipe(CreateRecipeModel createRecipeModel)
        {

           /* foreach (var ingredient in createRecipeModel.Ingredients)
            {
                this.ingredientService.CreateIngredient(ingredient);
            }*/

            this.recipeService.CreateRecipe(createRecipeModel);
        }


        [HttpPut]
        public void UpdateRecipe(UpdateRecipeModel updateRecipeModel)
        {
            foreach (var ingredient in updateRecipeModel.Ingredients)
            {
                this.ingredientService.UpdateIngredient(ingredient);
            }
            this.recipeService.UpdateRecipe(updateRecipeModel);
        }

        

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            this.recipeService.DeleteRecipe(id);
        }
    }
}
