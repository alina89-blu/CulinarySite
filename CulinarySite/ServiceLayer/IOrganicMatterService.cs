using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IOrganicMatterService
    {
        void CreateOrganicMatter(OrganicMatter organicMatter);
        void UpdateOrganicMatter(OrganicMatter organicMatter);
        void DeleteOrganicMatter(int id);
        IEnumerable<OrganicMatter> GetOrganicMatterList();
        OrganicMatter GetOrganicMatter(int id);
    }
}
