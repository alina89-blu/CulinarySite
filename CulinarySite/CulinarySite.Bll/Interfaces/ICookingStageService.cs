using CulinarySite.Common.Dtos.CookingStage;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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

