using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.RecipeIngredient;

namespace CulinarySite.Controllers
{
    public class RecipeIngredientController : BaseController
    {
        private readonly IRecipeIngredientService recipeIngredientService;
        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            this.recipeIngredientService = recipeIngredientService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RecipeIngredientListModel> GetRecipeIngredientList(bool withRelated)
        {
            return this.recipeIngredientService.GetRecipeIngredientList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public RecipeIngredientDetailModel GetRecipeIngredient(int id, bool withRelated)
        {
            return this.recipeIngredientService.GetRecipeIngredient(id, withRelated);
        }

        [HttpPost]
        public void CreateRecipeIngredient(CreateRecipeIngredientModel createRecipeIngredientModel)
        {
            this.recipeIngredientService.CreateRecipeIngredient(createRecipeIngredientModel);
        }

        [HttpPut]
        public void UpdateRecipeIngredient(UpdateRecipeIngredientModel updateRecipeIngredientModel)
        {
            this.recipeIngredientService.UpdateRecipeIngredient(updateRecipeIngredientModel);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipeIngredient(int id)
        {
            this.recipeIngredientService.DeleteRecipeIngredient(id);
        }
    }
}

