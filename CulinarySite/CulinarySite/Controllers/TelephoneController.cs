using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Telephone;
using CulinarySite.Common.ViewModels.Telephone;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryApi.Controllers
{
    public class TelephoneController : ApiController
    {
        private readonly ITelephoneService _telephoneService;
        private readonly IMapper _mapper;
        public TelephoneController(ITelephoneService telephoneService, IMapper mapper)
        {
            _telephoneService = telephoneService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<TelephoneListModel> GetTelephoneList(bool withRelated)
        {
            IEnumerable<TelephoneListDto> telephoneListDtos = _telephoneService.GetTelephoneList(withRelated);
            var telephoneListModels = new List<TelephoneListModel>();

            foreach (var telephoneListDto in telephoneListDtos)
            {
                telephoneListModels.Add(_mapper.Map<TelephoneListModel>(telephoneListDto));
            }
            return telephoneListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public TelephoneDetailModel GetTelephone(int id, bool withRelated)
        {
            TelephoneDetailDto telephoneDetailDto = _telephoneService.GetTelephone(id, withRelated);
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
