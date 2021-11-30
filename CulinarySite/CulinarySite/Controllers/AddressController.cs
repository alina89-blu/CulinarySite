using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Database;
using System.Linq;
using System.Collections.Generic;

namespace CulinarySite.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        [HttpGet]
        public IEnumerable<Address> GetAddressList()
        {
            return this.addressService.GetAddressList().ToList();
        }
        [HttpGet("{id}")]
        public Address GetAddress(int id)
        {
            return this.addressService.GetAddress(id);
        }
        [HttpPost]
        public void CreateAddress(Address address)
        {
            this.addressService.CreateAddress(address);
        }
        [HttpPut]
        public void UpdateAddress(Address address)
        {
            this.addressService.UpdateAddress(address);
        }
        [HttpDelete("{id}")]
        public void DeleteAddress(int id)
        {
            this.addressService.DeleteAddress(id);
        }

    }
}





