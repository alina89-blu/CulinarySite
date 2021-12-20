using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface ICookingStageService
    {
        void CreateCookingStage(CookingStage cookingStage);
        void UpdateCookingStage(CookingStage cookingStage);
        void DeleteCookingStage(int id);
        IEnumerable<CookingStage> GetCookingStageListWithInclude();
        CookingStage GetCookingStageWithInclude(int id);
    }
}

