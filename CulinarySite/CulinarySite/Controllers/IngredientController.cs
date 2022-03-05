using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Ingredient;

namespace CulinarySite.Controllers
{
    public class IngredientController : BaseController
    {
        private readonly IIngredientService ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<IngredientListModel> GetIngredientList(bool withRelated)
        {
            return this.ingredientService.GetIngredientList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public IngredientDetailModel GetIngredient(int id, bool withRelated)
        {
            return this.ingredientService.GetIngredient(id, withRelated);
        }

        [HttpPost]
        public void CreateIngredient(CreateIngredientModel createIngredientModel)
        {
            this.ingredientService.CreateIngredient(createIngredientModel);
        }

        [HttpPut]
        public void UpdateIngredient(UpdateIngredientModel updateIngredientModel)
        {
            this.ingredientService.UpdateIngredient(updateIngredientModel);
        }

        [HttpDelete("{id}")]
        public void DeleteIngredient(int id)
        {
            this.ingredientService.DeleteIngredient(id);
        }
    }
}

