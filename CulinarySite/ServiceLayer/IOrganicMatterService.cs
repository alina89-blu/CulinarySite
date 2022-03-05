using System.Collections.Generic;
using ServiceLayer.ViewModels.OrganicMatter;

namespace ServiceLayer
{
    public interface IOrganicMatterService
    {
        void CreateOrganicMatter(CreateOrganicMatterModel createOrganicMatterModel);
        void UpdateOrganicMatter(UpdateOrganicMatterModel updateOrganicMatterModel);
        void DeleteOrganicMatter(int id);
        IEnumerable<OrganicMatterListModel> GetOrganicMatterList();
        OrganicMatterDetailModel GetOrganicMatter(int id);
    }
}
