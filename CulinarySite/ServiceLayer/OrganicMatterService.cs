using Database;
using Repositories;
using System.Collections.Generic;

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

        public void CreateOrganicMatter(OrganicMatter organicMatter)
        {
            this.organicMatterWriteRepository.Create(organicMatter);
            this.organicMatterWriteRepository.Save();
        }

        public void UpdateOrganicMatter(OrganicMatter organicMatter)
        {
            this.organicMatterWriteRepository.Update(organicMatter);
            this.organicMatterWriteRepository.Save();
        }

        public void DeleteOrganicMatter(int id)
        {
            this.organicMatterWriteRepository.Delete(id);
            this.organicMatterWriteRepository.Save();
        }

        public IEnumerable<OrganicMatter> GetOrganicMatterList()
        {
            return this.organicMatterReadOnlyRepository.GetItemList();
        }

        public OrganicMatter GetOrganicMatter(int id)
        {
            return this.organicMatterReadOnlyRepository.GetItem(id);
        }
    }
}
