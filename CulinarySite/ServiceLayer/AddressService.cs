using Database;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AddressService : IAddressService
    {
        private readonly IReadOnlyGenericRepository<Address> addressReadOnlyRepository;
        private readonly IWriteGenericRepository<Address> addressWriteRepository;

        public AddressService(
            IReadOnlyGenericRepository<Address> addressReadOnlyRepository, 
            IWriteGenericRepository<Address> addressWriteRepository)
        {
            this.addressReadOnlyRepository = addressReadOnlyRepository;
            this.addressWriteRepository = addressWriteRepository;
        }

        public void CreateAddress(Address address)
        {
            this.addressWriteRepository.Create(address);
            this.addressWriteRepository.Save();
        }
        public void UpdateAddress(Address address)
        {
            this.addressWriteRepository.Update(address);
            this.addressWriteRepository.Save();
        }
        public void DeleteAddress(int id)
        {
            this.addressWriteRepository.Delete(id);
            this.addressWriteRepository.Save();

        }        
        public IEnumerable<Address> GetAddressList()
        {
            return this.addressReadOnlyRepository.GetItemList();
        }
        public Address GetAddress(int id)
        {
            return this.addressReadOnlyRepository.GetItem(id);
        }
    }
}
