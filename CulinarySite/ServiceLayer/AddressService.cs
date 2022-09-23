using AutoMapper;
using Database;
using Repositories;
using ServiceLayer.Dtos.Address;
using System.Collections.Generic;

namespace ServiceLayer
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

        /*public void CreateAddress(CreateAddressModel createAddressModel )
        {
            var address = new Address
            {
                Name = createAddressModel.Name
            };
            this.addressWriteRepository.Create(address);
            this.addressWriteRepository.Save();
        }*/

        /*public void UpdateAddress(UpdateAddressModel updateAddressModel )
       {
           var address = new Address
           {
               Id = updateAddressModel.Id,
               Name = updateAddressModel.Name
           };
           this.addressWriteRepository.Update(address);
           this.addressWriteRepository.Save();
       }*/

        /* public IEnumerable<AddressListModel> GetAddressList()
         {
             IEnumerable<Address> addresses = this._addressReadOnlyRepository.GetItemList();
             List<AddressListModel> addressListModels = new List<AddressListModel>();

             foreach(var address in addresses)
             {
                 addressListModels.Add(new AddressListModel
                 {
                     Id = address.Id,
                     Name = address.Name
                 });
             }
             return addressListModels;
         }*/

        /* public AddressDetailModel GetAddress(int id)
        {
            Address address = this._addressReadOnlyRepository.GetItem(id);
            AddressDetailModel addressDetailModel = new AddressDetailModel
            {
                Id = address.Id,
                Name = address.Name
            };
            return addressDetailModel;
        }*/


    }
}
