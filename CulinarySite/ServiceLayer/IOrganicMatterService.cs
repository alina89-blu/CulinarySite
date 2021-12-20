using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
 public interface    IOrganicMatterService
    {
        void CreateOrganicMatter(OrganicMatter organicMatter);
        void UpdateOrganicMatter(OrganicMatter organicMatter);
        void DeleteOrganicMatter(int id);
        IEnumerable<OrganicMatter> GetOrganicMatterList();
        OrganicMatter GetOrganicMatter(int id);
    }
}
