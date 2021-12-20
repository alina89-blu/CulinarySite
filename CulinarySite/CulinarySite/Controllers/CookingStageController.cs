using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Database;

namespace CulinarySite.Controllers
{
    public class CookingStageController : BaseController
    {
        private readonly ICookingStageService cookingStageService;
        public CookingStageController(ICookingStageService cookingStageService)
        {
            this.cookingStageService = cookingStageService;
        }

        [HttpGet]
        public IEnumerable<CookingStage> GetCookingStageListWithInclude()
        {
            return this.cookingStageService.GetCookingStageListWithInclude();
        }

        [HttpGet("{id}")]
        public CookingStage GetCookingStageWithInclude(int id)
        {
            return this.cookingStageService.GetCookingStageWithInclude(id);
        }

        [HttpPost]
        public void CreateCookingStage(CookingStage cookingStage)
        {
            this.cookingStageService.CreateCookingStage(cookingStage);
        }

        [HttpPut]
        public void UpdateCookingStage(CookingStage cookingStage)
        {
            this.cookingStageService.UpdateCookingStage(cookingStage);
        }

        [HttpDelete("{id}")]
        public void DeleteCookingStage(int id)
        {
            this.cookingStageService.DeleteCookingStage(id);
        }
    }
}

