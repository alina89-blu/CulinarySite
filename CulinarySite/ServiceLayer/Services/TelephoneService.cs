using AutoMapper;
using Database.Entities;
using Repositories;
using ServiceLayer.Dtos.Telephone;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class TelephoneService : ITelephoneService
    {
        private readonly IReadOnlyGenericRepository<Telephone> _telephoneReadOnlyRepository;
        private readonly IWriteGenericRepository<Telephone> _telephoneWriteRepository;
        private readonly IMapper _mapper;
        public TelephoneService(
            IReadOnlyGenericRepository<Telephone> telephoneReadOnlyRepository,
            IWriteGenericRepository<Telephone> telephoneWriteRepository,
            IMapper mapper)
        {
            _telephoneReadOnlyRepository = telephoneReadOnlyRepository;
            _telephoneWriteRepository = telephoneWriteRepository;
            _mapper = mapper;
        }

        public void CreateTelephone(CreateTelephoneDto createTelephoneDto)
        {
            Telephone telephone = _mapper.Map<Telephone>(createTelephoneDto);

            _telephoneWriteRepository.Create(telephone);
            _telephoneWriteRepository.Save();
        }

        public void UpdateTelephone(UpdateTelephoneDto updateTelephoneDto)
        {
            Telephone telephone = _mapper.Map<Telephone>(updateTelephoneDto);

            _telephoneWriteRepository.Update(telephone);
            _telephoneWriteRepository.Save();
        }

        public void DeleteTelephone(int id)
        {
            _telephoneWriteRepository.Delete(id);
            _telephoneWriteRepository.Save();
        }

        public IEnumerable<TelephoneListDto> GetTelephoneList(bool withRelated)
        {
            IEnumerable<Telephone> telephones;
            var telephoneListDtos = new List<TelephoneListDto>();

            if (withRelated)
            {
                telephones = _telephoneReadOnlyRepository.GetItemListWithInclude(x => x.Restaurant);

                foreach (var telephone in telephones)
                {
                    telephoneListDtos.Add(_mapper.Map<TelephoneListDto>(telephone));
                }

                return telephoneListDtos;
            }

            telephones = _telephoneReadOnlyRepository.GetItemList();

            foreach (var telephone in telephones)
            {
                telephoneListDtos.Add(_mapper.Map<TelephoneListDto>(telephone));
            }

            return telephoneListDtos;
        }

        public TelephoneDetailDto GetTelephone(int id, bool withRelated)
        {
            Telephone telephone;
            var telephoneDetailDto = new TelephoneDetailDto();

            if (withRelated)
            {
                telephone = _telephoneReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Restaurant);

                telephoneDetailDto = _mapper.Map<TelephoneDetailDto>(telephone);

                return telephoneDetailDto;
            }

            telephone = _telephoneReadOnlyRepository.GetItem(id);

            telephoneDetailDto = _mapper.Map<TelephoneDetailDto>(telephone);

            return telephoneDetailDto;
        }
    }
}
