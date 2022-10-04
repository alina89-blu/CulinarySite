using System.Collections.Generic;
using ServiceLayer.Dtos.OrganicMatter;

namespace ServiceLayer
{
    public interface IOrganicMatterService
    {
        void CreateOrganicMatter(CreateOrganicMatterDto createOrganicMatterDto);
        void UpdateOrganicMatter(UpdateOrganicMatterDto updateOrganicMatterDto);
        void DeleteOrganicMatter(int id);
        IEnumerable<OrganicMatterListDto> GetOrganicMatterList();
        OrganicMatterDetailDto GetOrganicMatter(int id);
    }
}
