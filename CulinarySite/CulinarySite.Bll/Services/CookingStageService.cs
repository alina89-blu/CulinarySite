using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.CookingStage;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
{
    public class CookingStageService : ICookingStageService
    {
        private readonly IReadOnlyGenericRepository<CookingStage> _cookingStageReadOnlyRepository;
        private readonly IWriteGenericRepository<CookingStage> _cookingStageWriteRepository;
        private readonly IMapper _mapper;
        public CookingStageService(
            IReadOnlyGenericRepository<CookingStage> cookingStageReadOnlyRepository,
            IWriteGenericRepository<CookingStage> cookingStageWriteRepository,
             IMapper mapper)
        {
            _cookingStageReadOnlyRepository = cookingStageReadOnlyRepository;
            _cookingStageWriteRepository = cookingStageWriteRepository;
            _mapper = mapper;
        }

        public void CreateCookingStage(CreateCookingStageDto createCookingStageDto)
        {
            CookingStage cookingStage = _mapper.Map<CookingStage>(createCookingStageDto);

            _cookingStageWriteRepository.Create(cookingStage);
            _cookingStageWriteRepository.Save();
        }

        public void UpdateCookingStage(UpdateCookingStageDto updateCookingStageDto)
        {
            CookingStage cookingStage = _mapper.Map<CookingStage>(updateCookingStageDto);

            _cookingStageWriteRepository.Update(cookingStage);
            _cookingStageWriteRepository.Save();
        }

        public void DeleteCookingStage(int id)
        {
            _cookingStageWriteRepository.Delete(id);
            _cookingStageWriteRepository.Save();
        }

        public IEnumerable<CookingStageListDto> GetCookingStageList(bool withRelated)
        {
            IEnumerable<CookingStage> cookingStages;
            IEnumerable<CookingStageListDto> cookingStageListDtos;

            if (withRelated)
            {
                cookingStages = _cookingStageReadOnlyRepository.GetItemListWithInclude(x => x.Recipe);

                cookingStageListDtos = cookingStages.Select(x => _mapper.Map<CookingStageListDto>(x));

                return cookingStageListDtos;
            }

            cookingStages = _cookingStageReadOnlyRepository.GetItemList();

            cookingStageListDtos = cookingStages.Select(x => _mapper.Map<CookingStageListDto>(x));

            return cookingStageListDtos;
        }

        public CookingStageDetailDto GetCookingStage(int id, bool withRelated)
        {
            var cookingStage = new CookingStage();
            var cookingStageDetailDto = new CookingStageDetailDto();

            if (withRelated)
            {
                cookingStage = _cookingStageReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipe);

                cookingStageDetailDto = _mapper.Map<CookingStageDetailDto>(cookingStage);

                return cookingStageDetailDto;
            }

            cookingStage = _cookingStageReadOnlyRepository.GetItem(id);

            cookingStageDetailDto = _mapper.Map<CookingStageDetailDto>(cookingStage);

            return cookingStageDetailDto;
        }
    }
}


