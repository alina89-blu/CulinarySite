using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.OrganicMatter;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
{
    public class OrganicMatterService : IOrganicMatterService
    {
        private readonly IReadOnlyGenericRepository<OrganicMatter> _organicMatterReadOnlyRepository;
        private readonly IWriteGenericRepository<OrganicMatter> _organicMatterWriteRepository;
        private readonly IMapper _mapper;
        public OrganicMatterService(
            IReadOnlyGenericRepository<OrganicMatter> organicMatterReadOnlyRepository,
            IWriteGenericRepository<OrganicMatter> organicMatterWriteRepository,
            IMapper mapper)
        {
            _organicMatterReadOnlyRepository = organicMatterReadOnlyRepository;
            _organicMatterWriteRepository = organicMatterWriteRepository;
            _mapper = mapper;
        }

        public void CreateOrganicMatter(CreateOrganicMatterDto createOrganicMatterDto)
        {
            OrganicMatter organicMatter = _mapper.Map<OrganicMatter>(createOrganicMatterDto);

            _organicMatterWriteRepository.Create(organicMatter);
            _organicMatterWriteRepository.Save();
        }

        public void UpdateOrganicMatter(UpdateOrganicMatterDto updateOrganicMatterDto)
        {
            OrganicMatter organicMatter = _mapper.Map<OrganicMatter>(updateOrganicMatterDto);

            _organicMatterWriteRepository.Update(organicMatter);
            _organicMatterWriteRepository.Save();
        }

        public void DeleteOrganicMatter(int id)
        {
            _organicMatterWriteRepository.Delete(id);
            _organicMatterWriteRepository.Save();
        }

        public IEnumerable<OrganicMatterListDto> GetOrganicMatterList()
        {
            IEnumerable<OrganicMatter> organicMatters = _organicMatterReadOnlyRepository.GetItemList();
            var organicMatterListDtos = organicMatters.Select(x => _mapper.Map<OrganicMatterListDto>(x));           

            return organicMatterListDtos;
        }

        public OrganicMatterDetailDto GetOrganicMatter(int id)
        {
            OrganicMatter organicMatter = _organicMatterReadOnlyRepository.GetItem(id);
            OrganicMatterDetailDto organicMatterDetailDto = _mapper.Map<OrganicMatterDetailDto>(organicMatter);

            return organicMatterDetailDto;
        }
    }
}
