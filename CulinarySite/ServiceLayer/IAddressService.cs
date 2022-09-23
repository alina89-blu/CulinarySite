using ServiceLayer.Dtos.Address;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IAddressService
    {
        void CreateAddress(CreateAddressDto createAddressDto);
        void UpdateAddress(UpdateAddressDto updateAddressDto );
        void DeleteAddress(int id);
        IEnumerable<AddressListDto> GetAddressList();
        AddressDetailDto GetAddress(int id);
    }
}
