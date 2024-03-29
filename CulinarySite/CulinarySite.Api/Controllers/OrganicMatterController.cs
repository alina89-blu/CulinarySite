﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.OrganicMatter;
using CulinarySite.Common.Dtos.OrganicMatter;
using CulinarySite.Bll.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CulinarySite.Api.Controllers
{
    public class OrganicMatterController : ApiController
    {
        private readonly IOrganicMatterService _organicMatterService;
        private readonly IMapper _mapper;
        public OrganicMatterController(IOrganicMatterService organicMatterService, IMapper mapper)
        {
            _organicMatterService = organicMatterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<OrganicMatterListModel> GetOrganicMatterList()
        {
            IEnumerable<OrganicMatterListDto> organicMatterListDtos = _organicMatterService.GetOrganicMatterList();
            var organicMatterListModels = organicMatterListDtos.Select(x => _mapper.Map<OrganicMatterListModel>(x));         

            return organicMatterListModels;
        }

        [HttpGet("{id}")]
        public OrganicMatterDetailModel GetOrganicMatter(int id)
        {
            OrganicMatterDetailDto organicMatterDetailDto = _organicMatterService.GetOrganicMatter(id);
            OrganicMatterDetailModel organicMatterDetailModel = _mapper.Map<OrganicMatterDetailModel>(organicMatterDetailDto);

            return organicMatterDetailModel;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public void CreateOrganicMatter(CreateOrganicMatterModel createOrganicMatterModel)
        {
            CreateOrganicMatterDto createOrganicMatterDto = _mapper.Map<CreateOrganicMatterDto>(createOrganicMatterModel);
            _organicMatterService.CreateOrganicMatter(createOrganicMatterDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public void UpdateOrganicMatter(UpdateOrganicMatterModel updateOrganicMatterModel)
        {
            UpdateOrganicMatterDto updateOrganicMatterDto = _mapper.Map<UpdateOrganicMatterDto>(updateOrganicMatterModel);
            _organicMatterService.UpdateOrganicMatter(updateOrganicMatterDto);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public void DeleteOrganicMatter(int id)
        {
            _organicMatterService.DeleteOrganicMatter(id);
        }
    }
}
