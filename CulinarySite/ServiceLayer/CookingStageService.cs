using System.Collections.Generic;
using Repositories;
using Database;
using ServiceLayer.ViewModels.CookingStage;

namespace ServiceLayer
{
    public class CookingStageService : ICookingStageService
    {
        private readonly IReadOnlyGenericRepository<CookingStage> cookingStageReadOnlyRepository;
        private readonly IWriteGenericRepository<CookingStage> cookingStageWriteRepository;
        public CookingStageService(
            IReadOnlyGenericRepository<CookingStage> cookingStageReadOnlyRepository,
            IWriteGenericRepository<CookingStage> cookingStageWriteRepository)
        {
            this.cookingStageReadOnlyRepository = cookingStageReadOnlyRepository;
            this.cookingStageWriteRepository = cookingStageWriteRepository;
        }

        public void CreateCookingStage(CreateCookingStageModel createCookingStageModel)
        {
            var cookingStage = new CookingStage
            {
                Content = createCookingStageModel.Content,
                RecipeId = createCookingStageModel.RecipeId
            };
            this.cookingStageWriteRepository.Create(cookingStage);
            this.cookingStageWriteRepository.Save();
        }

        public void UpdateCookingStage(UpdateCookingStageModel updateCookingStageModel)
        {
            var cookingStage = new CookingStage
            {
                Id = updateCookingStageModel.CookingStageId,
                Content = updateCookingStageModel.Content,
                RecipeId = updateCookingStageModel.RecipeId
            };
            this.cookingStageWriteRepository.Update(cookingStage);
            this.cookingStageWriteRepository.Save();
        }

        public void DeleteCookingStage(int id)
        {
            this.cookingStageWriteRepository.Delete(id);
            this.cookingStageWriteRepository.Save();
        }

        public IEnumerable<CookingStageListModel> GetCookingStageList(bool withRelated)
        {
            IEnumerable<CookingStage> cookingStages;
            List<CookingStageListModel> cookingStageListModels = new List<CookingStageListModel>();
            if (withRelated)
            {
                cookingStages = this.cookingStageReadOnlyRepository.GetItemListWithInclude(
                    x => x.Recipe,
                    x => x.Images);
                foreach (var cookingStage in cookingStages)
                {
                    cookingStageListModels.Add(new CookingStageListModel
                    {
                        CookingStageId = cookingStage.Id,
                        Content = cookingStage.Content,
                        RecipeName = cookingStage.Recipe.Name
                    });
                }
                return cookingStageListModels;
            }
            cookingStages = this.cookingStageReadOnlyRepository.GetItemList();
            foreach (var cookingStage in cookingStages)
            {
                cookingStageListModels.Add(new CookingStageListModel
                {
                    CookingStageId = cookingStage.Id,
                    Content = cookingStage.Content,
                });
            }
            return cookingStageListModels;
        }

        public CookingStageDetailModel GetCookingStage(int id, bool withRelated)
        {
            var cookingStage = new CookingStage();
            CookingStageDetailModel cookingStageDetailModel = new CookingStageDetailModel();
            if (withRelated)
            {
                cookingStage = this.cookingStageReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipe,
                x => x.Images);
                cookingStageDetailModel = new CookingStageDetailModel
                {
                    CookingStageId = cookingStage.Id,
                    Content = cookingStage.Content,
                    RecipeId = cookingStage.RecipeId
                };
                return cookingStageDetailModel;
            }
            cookingStage = this.cookingStageReadOnlyRepository.GetItem(id);
            cookingStageDetailModel = new CookingStageDetailModel
            {
                CookingStageId = cookingStage.Id,
                Content = cookingStage.Content,               
            };
            return cookingStageDetailModel;
        }
    }
}


