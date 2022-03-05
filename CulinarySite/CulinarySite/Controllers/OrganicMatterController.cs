using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.OrganicMatter;

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
        public IEnumerable<OrganicMatterListModel> GetOrganicMatterList()
        {
            return this.organicMatterService.GetOrganicMatterList();
        }

        [HttpGet("{id}")]
        public OrganicMatterDetailModel GetOrganicMatter(int id)
        {
            return this.organicMatterService.GetOrganicMatter(id);
        }

        [HttpPost]
        public void CreateOrganicMatter(CreateOrganicMatterModel createOrganicMatterModel)
        {
            this.organicMatterService.CreateOrganicMatter(createOrganicMatterModel);
        }

        [HttpPut]
        public void UpdateOrganicMatter(UpdateOrganicMatterModel updateOrganicMatterModel)
        {
            this.organicMatterService.UpdateOrganicMatter(updateOrganicMatterModel);
        }

        [HttpDelete("{id}")]
        public void DeleteOrganicMatter(int id)
        {
            this.organicMatterService.DeleteOrganicMatter(id);
        }
    }
}
