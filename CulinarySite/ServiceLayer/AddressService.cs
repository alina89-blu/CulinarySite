using Database;
using Repositories;
using ServiceLayer.ViewModels.Address;
using System.Collections.Generic;

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

        public void CreateAddress(CreateAddressModel createAddressModel )
        {
            var address = new Address
            {
                Name = createAddressModel.Name
            };
            this.addressWriteRepository.Create(address);
            this.addressWriteRepository.Save();
        }

        public void UpdateAddress(UpdateAddressModel updateAddressModel )
        {
            var address = new Address
            {
                Id = updateAddressModel.Id,
                Name = updateAddressModel.Name
            };
            this.addressWriteRepository.Update(address);
            this.addressWriteRepository.Save();
        }

        public void DeleteAddress(int id)
        {
            this.addressWriteRepository.Delete(id);
            this.addressWriteRepository.Save();
        }

        public IEnumerable<AddressListModel> GetAddressList()
        {
            IEnumerable<Address> addresses = this.addressReadOnlyRepository.GetItemList();
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
        }

        public AddressDetailModel GetAddress(int id)
        {
            Address address= this.addressReadOnlyRepository.GetItem(id);
            AddressDetailModel addressDetailModel = new AddressDetailModel
            {
                Id = address.Id,
                Name = address.Name
            };
            return addressDetailModel;
        }
    }
}
