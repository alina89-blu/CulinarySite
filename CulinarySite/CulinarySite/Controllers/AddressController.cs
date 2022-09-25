using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Address;
using AutoMapper;
using ServiceLayer.Dtos.Address;

namespace CulinarySite.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<AddressListModel> GetAddressList()
        {
            IEnumerable<AddressListDto> addressListDtos = _addressService.GetAddressList();
            var addressListModels = new List<AddressListModel>();

            foreach (AddressListDto addressListDto in addressListDtos)
            {
                addressListModels.Add(_mapper.Map<AddressListModel>(addressListDto));
            }

            return addressListModels;
        }

        [HttpGet("{id}")]
        public AddressDetailModel GetAddress(int id)
        {
            AddressDetailDto addressDetailDto = _addressService.GetAddress(id);
            AddressDetailModel addressDetailModel = _mapper.Map<AddressDetailModel>(addressDetailDto);

            return addressDetailModel;
        }

        [HttpPost]
        public void CreateAddress(CreateAddressModel createAddressModel)
        {
            var сreateAddressDto = _mapper.Map<CreateAddressDto>(createAddressModel);
            _addressService.CreateAddress(сreateAddressDto);
        }

        [HttpPut]
        public void UpdateAddress(UpdateAddressModel updateAddressModel)
        {
            var updateAddressDto = _mapper.Map<UpdateAddressDto>(updateAddressModel);
            _addressService.UpdateAddress(updateAddressDto);
        }

        [HttpDelete("{id}")]
        public void DeleteAddress(int id)
        {
            _addressService.DeleteAddress(id);
        }
    }
}





