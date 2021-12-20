using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace ServiceLayer
{
    public interface ICookingStageService
    {
        void CreateCookingStage(CookingStage cookingStage);
        void UpdateCookingStage(CookingStage cookingStage);
        void DeleteCookingStage(int id);
        IEnumerable<CookingStage> GetCookingStageListWithInclude();
        CookingStage GetCookingStageWithInclude(int id);//
    }
}

