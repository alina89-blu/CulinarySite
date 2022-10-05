using CulinarySite.Common.Dtos.Address;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
