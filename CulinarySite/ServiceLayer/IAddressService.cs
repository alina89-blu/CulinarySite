
using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IAddressService
    {
        void CreateAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(int id);      
        IEnumerable<Address> GetAddressList();
        Address GetAddress(int id);
        
    }
}
