using System.Collections.Generic;
using Database;
using ServiceLayer.ViewModels.CookingStage;

namespace ServiceLayer
{
    public interface ICookingStageService
    {
        void CreateCookingStage(CreateCookingStageModel createCookingStageModel);
        void UpdateCookingStage(UpdateCookingStageModel updateCookingStageModel);
        void DeleteCookingStage(int id);
        IEnumerable<CookingStageListModel> GetCookingStageList(bool withRelated);
        CookingStageDetailModel GetCookingStage(int id, bool withRelated);
    }
}

