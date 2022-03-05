using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Database;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Address;

namespace CulinarySite.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService addressService;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<AddressListModel> GetAddressList()
        {
            return this.addressService.GetAddressList();
        }

        [HttpGet("{id}")]
        public AddressDetailModel GetAddress(int id)
        {
            return this.addressService.GetAddress(id);
        }

        [HttpPost]
        public void CreateAddress(CreateAddressModel createAddressModel)
        {
            this.addressService.CreateAddress(createAddressModel);
        }

        [HttpPut]
        public void UpdateAddress(UpdateAddressModel updateAddressModel)
        {
            this.addressService.UpdateAddress(updateAddressModel);
        }

        [HttpDelete("{id}")]
        public void DeleteAddress(int id)
        {
            this.addressService.DeleteAddress(id);
        }
    }
}





