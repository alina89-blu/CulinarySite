using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.OrganicMatter;

namespace ServiceLayer
{
    public class OrganicMatterService : IOrganicMatterService
    {
        private readonly IReadOnlyGenericRepository<OrganicMatter> organicMatterReadOnlyRepository;
        private readonly IWriteGenericRepository<OrganicMatter> organicMatterWriteRepository;
        public OrganicMatterService(
            IReadOnlyGenericRepository<OrganicMatter> organicMatterReadOnlyRepository,
            IWriteGenericRepository<OrganicMatter> organicMatterWriteRepository)
        {
            this.organicMatterReadOnlyRepository = organicMatterReadOnlyRepository;
            this.organicMatterWriteRepository = organicMatterWriteRepository;
        }

        public void CreateOrganicMatter(CreateOrganicMatterModel createOrganicMatterModel)
        {
            var organicMatter = new OrganicMatter
            {
                Name = createOrganicMatterModel.Name,
                Unit=createOrganicMatterModel.Unit,
                Quantity=createOrganicMatterModel.Quantity
            };
            this.organicMatterWriteRepository.Create(organicMatter);
            this.organicMatterWriteRepository.Save();
        }

        public void UpdateOrganicMatter(UpdateOrganicMatterModel updateOrganicMatterModel)
        {
            var organicMatter = new OrganicMatter
            {
                Id = updateOrganicMatterModel.OrganicMatterId,
                Name = updateOrganicMatterModel.Name,
                Unit = updateOrganicMatterModel.Unit,
                Quantity = updateOrganicMatterModel.Quantity
            };
            this.organicMatterWriteRepository.Update(organicMatter);
            this.organicMatterWriteRepository.Save();
        }

        public void DeleteOrganicMatter(int id)
        {
            this.organicMatterWriteRepository.Delete(id);
            this.organicMatterWriteRepository.Save();
        }

        public IEnumerable<OrganicMatterListModel> GetOrganicMatterList()
        {
            IEnumerable<OrganicMatter> organicMatters;
            List<OrganicMatterListModel> organicMatterListModels = new List<OrganicMatterListModel>();

            organicMatters = this.organicMatterReadOnlyRepository.GetItemList();
            foreach (var organicMatter in organicMatters)
            {
                organicMatterListModels.Add(new OrganicMatterListModel
                {
                    OrganicMatterId = organicMatter.Id,
                    Name = organicMatter.Name,
                    Unit=organicMatter.Unit,
                    Quantity=organicMatter.Quantity
                });
            }
            return organicMatterListModels;
        }

        public OrganicMatterDetailModel GetOrganicMatter(int id)
        {           
            OrganicMatter organicMatter = this.organicMatterReadOnlyRepository.GetItem(id);
            var organicMatterDetailModel = new OrganicMatterDetailModel
            {
                OrganicMatterId = organicMatter.Id,
                Name = organicMatter.Name,
                Unit=organicMatter.Unit,
                Quantity=organicMatter.Quantity
            };
            return organicMatterDetailModel;
        }
    }
}
