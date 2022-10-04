using System.Collections.Generic;
using ServiceLayer.Dtos.CookingStage;

namespace ServiceLayer
{
    public interface ICookingStageService
    {
        void CreateCookingStage(CreateCookingStageDto createCookingStageDto);
        void UpdateCookingStage(UpdateCookingStageDto updateCookingStageDto);
        void DeleteCookingStage(int id);
        IEnumerable<CookingStageListDto> GetCookingStageList(bool withRelated);
        CookingStageDetailDto GetCookingStage(int id, bool withRelated);
    }
}

