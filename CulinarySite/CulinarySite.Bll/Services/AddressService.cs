using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Address;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Collections.Generic;


namespace CulinarySite.Bll.Services
{
    public class AddressService : IAddressService
    {
        private readonly IReadOnlyGenericRepository<Address> _addressReadOnlyRepository;
        private readonly IWriteGenericRepository<Address> _addressWriteRepository;
        private readonly IMapper _mapper;
        public AddressService(
            IReadOnlyGenericRepository<Address> addressReadOnlyRepository,
            IWriteGenericRepository<Address> addressWriteRepository,
            IMapper mapper)
        {
            _addressReadOnlyRepository = addressReadOnlyRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
        }

        public void CreateAddress(CreateAddressDto createAddressDto)
        {
            Address address = _mapper.Map<Address>(createAddressDto);

            _addressWriteRepository.Create(address);
            _addressWriteRepository.Save();
        }

        public void UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            Address address = _mapper.Map<Address>(updateAddressDto);

            _addressWriteRepository.Update(address);
            _addressWriteRepository.Save();
        }

        public void DeleteAddress(int id)
        {
            _addressWriteRepository.Delete(id);
            _addressWriteRepository.Save();
        }

        public IEnumerable<AddressListDto> GetAddressList()
        {
            IEnumerable<Address> addresses = _addressReadOnlyRepository.GetItemList();
            var addressListDtos = new List<AddressListDto>();

            foreach (var address in addresses)
            {
                addressListDtos.Add(_mapper.Map<AddressListDto>(address));
            }
            return addressListDtos;
        }

        public AddressDetailDto GetAddress(int id)
        {
            Address address = _addressReadOnlyRepository.GetItem(id);
            AddressDetailDto addressDetailDto = _mapper.Map<AddressDetailDto>(address);
            return addressDetailDto;
        }

        
    }
}
