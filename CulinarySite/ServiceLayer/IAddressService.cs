using Database;
using ServiceLayer.ViewModels.Address;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IAddressService
    {
        void CreateAddress(CreateAddressModel createAddressModel);
        void UpdateAddress(UpdateAddressModel updateAddressModel );
        void DeleteAddress(int id);
        IEnumerable<AddressListModel> GetAddressList();
        AddressDetailModel GetAddress(int id);
    }
}
