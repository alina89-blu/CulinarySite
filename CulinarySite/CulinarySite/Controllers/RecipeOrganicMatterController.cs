using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.RecipeOrganicMatter;

namespace CulinarySite.Controllers
{
    public class RecipeOrganicMatterController : BaseController
    {
        private readonly IRecipeOrganicMatterService recipeOrganicMatterService;
        public RecipeOrganicMatterController(IRecipeOrganicMatterService recipeOrganicMatterService)
        {
            this.recipeOrganicMatterService = recipeOrganicMatterService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RecipeOrganicMatterListModel> GetRecipeOrganicMatterList(bool withRelated)
        {
            return this.recipeOrganicMatterService.GetRecipeOrganicMatterList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public RecipeOrganicMatterDetailModel GetRecipeOrganicMatter(int id, bool withRelated)
        {
            return this.recipeOrganicMatterService.GetRecipeOrganicMatter(id, withRelated);
        }

        [HttpPost]
        public void CreateRecipeOrganicMatter(CreateRecipeOrganicMatterModel createRecipeOrganicMatterModel)
        {
            this.recipeOrganicMatterService.CreateRecipeOrganicMatter(createRecipeOrganicMatterModel);
        }

        [HttpPut]
        public void UpdateRecipeOrganicMatter(UpdateRecipeOrganicMatterModel updateRecipeOrganicMatterModel)
        {
            this.recipeOrganicMatterService.UpdateRecipeOrganicMatter(updateRecipeOrganicMatterModel);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipeOrganicMatter(int id)
        {
            this.recipeOrganicMatterService.DeleteRecipeOrganicMatter(id);
        }
    }
}

