using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Telephone;
using CulinarySite.Common.Exceptions;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CulinarySite.Bll.Services
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
            var telephoneNames = _telephoneReadOnlyRepository.GetItemList().Select(x => x.Number);

            if (telephoneNames.Contains(createTelephoneDto.Number))
            {
                throw new ValidationException($"The telephone number:{createTelephoneDto.Number} already exists.");
            }

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
            IEnumerable<TelephoneListDto> telephoneListDtos ;

            if (withRelated)
            {
                telephones = _telephoneReadOnlyRepository.GetItemListWithInclude(x => x.Restaurant);
                telephoneListDtos = telephones.Select(x => _mapper.Map<TelephoneListDto>(x));

                return telephoneListDtos;
            }

            telephones = _telephoneReadOnlyRepository.GetItemList();
            telephoneListDtos = telephones.Select(x => _mapper.Map<TelephoneListDto>(x));

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
