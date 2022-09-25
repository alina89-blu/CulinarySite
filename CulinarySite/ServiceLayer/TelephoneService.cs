using AutoMapper;
using Database;
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

        public IEnumerable<TelephoneListDto> GetTelephoneList()
        {
            IEnumerable<Telephone> telephones = _telephoneReadOnlyRepository.GetItemList();
            var telephoneListDtos = new List<TelephoneListDto>();

            foreach (var telephone in telephones)
            {
                telephoneListDtos.Add(_mapper.Map<TelephoneListDto>(telephone));
            }

            return telephoneListDtos;
        }

        public TelephoneDetailDto GetTelephone(int id)
        {
            Telephone telephone = _telephoneReadOnlyRepository.GetItem(id);
            TelephoneDetailDto telephoneDetailDto = _mapper.Map<TelephoneDetailDto>(telephone);

            return telephoneDetailDto;
        }
    }
}
