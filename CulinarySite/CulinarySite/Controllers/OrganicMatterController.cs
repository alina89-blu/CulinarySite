using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class OrganicMatterController : BaseController
    {
        private readonly IOrganicMatterService organicMatterService;
        public OrganicMatterController(IOrganicMatterService organicMatterService)
        {
            this.organicMatterService = organicMatterService;
        }

        [HttpGet]
        public IEnumerable<OrganicMatter> GetOrganicMatterList()
        {
            return this.organicMatterService.GetOrganicMatterList();
        }

        [HttpGet("{id}")]
        public OrganicMatter GetOrganicMatter(int id)
        {
            return this.organicMatterService.GetOrganicMatter(id);
        }

        [HttpPost]
        public void CreateOrganicMatter(OrganicMatter organicMatter)
        {
            this.organicMatterService.CreateOrganicMatter(organicMatter);
        }

        [HttpPut]
        public void UpdateOrganicMatter(OrganicMatter organicMatter)
        {
            this.organicMatterService.UpdateOrganicMatter(organicMatter);
        }

        [HttpDelete("{id}")]
        public void DeleteOrganicMatter(int id)
        {
            this.organicMatterService.DeleteOrganicMatter(id);
        }
    }
}
