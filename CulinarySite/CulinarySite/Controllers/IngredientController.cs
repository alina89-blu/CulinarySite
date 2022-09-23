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
        public IEnumerable<IngredientListModel> GetIngredientList()
        {
            return this.ingredientService.GetIngredientList();
        }

        [HttpGet("{id}/{withRelated}")]
        public IngredientDetailModel GetIngredient(int id)
        {
            return this.ingredientService.GetIngredient(id);
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

