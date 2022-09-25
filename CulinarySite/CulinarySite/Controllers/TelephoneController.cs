using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Dtos.Telephone;
using ServiceLayer.ViewModels.Telephone;

namespace CulinarySite.Controllers
{
    public class TelephoneController : BaseController
    {
        private readonly ITelephoneService _telephoneService;
        private readonly IMapper _mapper;
        public TelephoneController(ITelephoneService telephoneService, IMapper mapper)
        {
            _telephoneService = telephoneService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TelephoneListModel> GetTelephoneList()
        {
            IEnumerable<TelephoneListDto> telephoneListDtos = _telephoneService.GetTelephoneList();
            var telephoneListModels = new List<TelephoneListModel>();

            foreach (var telephoneListDto in telephoneListDtos)
            {
                telephoneListModels.Add(_mapper.Map<TelephoneListModel>(telephoneListDto));
            }
            return telephoneListModels;
        }

        [HttpGet("{id}")]
        public TelephoneDetailModel GetTelephone(int id)
        {
            TelephoneDetailDto telephoneDetailDto = _telephoneService.GetTelephone(id);
            TelephoneDetailModel telephoneDetailModel = _mapper.Map<TelephoneDetailModel>(telephoneDetailDto);

            return telephoneDetailModel;
        }

        [HttpPost]
        public void CreateTelephone(CreateTelephoneModel createTelephoneModel)
        {
            CreateTelephoneDto createTelephoneDto = _mapper.Map<CreateTelephoneDto>(createTelephoneModel);
            _telephoneService.CreateTelephone(createTelephoneDto);
        }

        [HttpPut]
        public void UpdateTelephone(UpdateTelephoneModel updateTelephoneModel)
        {
            UpdateTelephoneDto updateTelephoneDto = _mapper.Map<UpdateTelephoneDto>(updateTelephoneModel);
            _telephoneService.UpdateTelephone(updateTelephoneDto);
        }

        [HttpDelete("{id}")]
        public void DeleteTelephone(int id)
        {
            _telephoneService.DeleteTelephone(id);
        }
    }
}
