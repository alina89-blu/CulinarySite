using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Recipe;

namespace CulinarySite.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IRecipeIngredientService recipeIngredientService;

        public RecipeController(IRecipeService recipeService, IRecipeIngredientService recipeIngredientService)
        {
            this.recipeService = recipeService;
            this.recipeIngredientService = recipeIngredientService;
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

            foreach (var createRecipeIngredientModel in createRecipeModel.RecipeIngredients)
            {
                this.recipeIngredientService.CreateRecipeIngredient(createRecipeIngredientModel);
            }

            this.recipeService.CreateRecipe(createRecipeModel);
        }  

        [HttpPut]
        public void UpdateRecipe(UpdateRecipeModel updateRecipeModel)
        {
            this.recipeService.UpdateRecipe(updateRecipeModel);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            this.recipeService.DeleteRecipe(id);
        }
    }
}
