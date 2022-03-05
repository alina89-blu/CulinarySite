using System.Collections.Generic;
using ServiceLayer.ViewModels.RecipeOrganicMatter;

namespace ServiceLayer
{
    public interface IRecipeOrganicMatterService
    {
        void CreateRecipeOrganicMatter(CreateRecipeOrganicMatterModel createRecipeOrganicMatterModel);
        void UpdateRecipeOrganicMatter(UpdateRecipeOrganicMatterModel updateRecipeOrganicMatterModel);
        void DeleteRecipeOrganicMatter(int id);
        IEnumerable<RecipeOrganicMatterListModel> GetRecipeOrganicMatterList(bool withRelated);
        RecipeOrganicMatterDetailModel GetRecipeOrganicMatter(int id, bool withRelated);
    }
}
