using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.ViewModels.Address;
using CulinarySite.Common.Dtos.Address;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CulinarySite.Api.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<AddressListModel> GetAddressList()
        {
            IEnumerable<AddressListDto> addressListDtos = _addressService.GetAddressList();
            var addressListModels = addressListDtos.Select(x => _mapper.Map<AddressListModel>(x));

            return addressListModels;
        }

        [HttpGet("{id}")]
        public AddressDetailModel GetAddress(int id)
        {
            AddressDetailDto addressDetailDto = _addressService.GetAddress(id);
            AddressDetailModel addressDetailModel = _mapper.Map<AddressDetailModel>(addressDetailDto);

            return addressDetailModel;
        }

        [Authorize]
        [HttpPost]
        public void CreateAddress(CreateAddressModel createAddressModel)
        {
            var сreateAddressDto = _mapper.Map<CreateAddressDto>(createAddressModel);
            _addressService.CreateAddress(сreateAddressDto);
        }

        [Authorize]
        [HttpPut]
        public void UpdateAddress(UpdateAddressModel updateAddressModel)
        {
            var updateAddressDto = _mapper.Map<UpdateAddressDto>(updateAddressModel);
            _addressService.UpdateAddress(updateAddressDto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteAddress(int id)
        {
            _addressService.DeleteAddress(id);
        }
    }
}





