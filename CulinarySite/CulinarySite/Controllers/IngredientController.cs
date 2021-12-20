using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class IngredientController : BaseController
    {
        private readonly IIngredientService ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public IEnumerable<Ingredient> GetIngredientListWithInclude()
        {
            return this.ingredientService.GetIngredientListWithInclude();
        }

        [HttpGet("{id}")]
        public Ingredient GetIngredientWithInclude(int id)
        {
            return this.ingredientService.GetIngredientWithInclude(id);
        }

        [HttpPost]
        public void CreateIngredient(Ingredient ingredient)
        {
            this.ingredientService.CreateIngredient(ingredient);
        }

        [HttpPut]
        public void UpdateIngredient(Ingredient ingredient)
        {
            this.ingredientService.UpdateIngredient(ingredient);
        }

        [HttpDelete("{id}")]
        public void DeleteIngredient(int id)
        {
            this.ingredientService.DeleteIngredient(id);
        }
    }
}
