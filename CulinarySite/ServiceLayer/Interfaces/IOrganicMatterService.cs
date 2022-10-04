using CulinarySite.Common.Dtos.OrganicMatter;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
