using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.CookingStage;

namespace CulinarySite.Controllers
{
    public class CookingStageController : BaseController
    {
        private readonly ICookingStageService cookingStageService;
        public CookingStageController(ICookingStageService cookingStageService)
        {
            this.cookingStageService = cookingStageService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<CookingStageListModel> GetCookingStageList(bool withRelated)
        {
            return this.cookingStageService.GetCookingStageList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public CookingStageDetailModel GetCookingStage(int id, bool withRelated)
        {
            return this.cookingStageService.GetCookingStage(id, withRelated);
        }

        [HttpPost]
        public void CreateCookingStage(CreateCookingStageModel createCookingStageModel)
        {
            this.cookingStageService.CreateCookingStage(createCookingStageModel);
        }

        [HttpPut]
        public void UpdateCookingStage(UpdateCookingStageModel updateCookingStageModel)
        {
            this.cookingStageService.UpdateCookingStage(updateCookingStageModel);
        }

        [HttpDelete("{id}")]
        public void DeleteCookingStage(int id)
        {
            this.cookingStageService.DeleteCookingStage(id);
        }
    }
}

