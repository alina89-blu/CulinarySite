﻿using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.CookingStage;
using CulinarySite.Common.ViewModels.CookingStage;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CulinarySite.Common.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace CulinarySite.Api.Controllers
{
    public class CookingStageController : ApiController
    {
        private readonly ICookingStageService _cookingStageService;
        private readonly IMapper _mapper;
        public CookingStageController(ICookingStageService cookingStageService, IMapper mapper)
        {
            _cookingStageService = cookingStageService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<CookingStageListModel> GetCookingStageList(bool withRelated)
        {
            IEnumerable < CookingStageListDto > cookingStageListDtos= _cookingStageService.GetCookingStageList(withRelated);
            var cookingStageListModels = cookingStageListDtos.Select(x => _mapper.Map<CookingStageListModel>(x));

            return cookingStageListModels;
        }
       
        [HttpGet("{id}/{withRelated}")]
        public CookingStageDetailModel GetCookingStage(int id, bool withRelated)
        {
            CookingStageDetailDto cookingStageDetailDto= _cookingStageService.GetCookingStage(id, withRelated);
            CookingStageDetailModel cookingStageDetailModel = _mapper.Map<CookingStageDetailModel>(cookingStageDetailDto);

            return cookingStageDetailModel;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public void CreateCookingStage(CreateCookingStageModel createCookingStageModel)
        {
            var createCookingStageDto = _mapper.Map<CreateCookingStageDto>(createCookingStageModel);
            _cookingStageService.CreateCookingStage(createCookingStageDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public void UpdateCookingStage(UpdateCookingStageModel updateCookingStageModel)
        {
            var updateCookingStageDto = _mapper.Map<UpdateCookingStageDto>(updateCookingStageModel);
            _cookingStageService.UpdateCookingStage(updateCookingStageDto);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public void DeleteCookingStage(int id)
        {
            _cookingStageService.DeleteCookingStage(id);
        }

        [HttpGet("paged")]
        public PagedList<CookingStageListModel> GetPaginatedCookingStages([FromQuery] PagingParameters pagingParameters)
        {
            PagedList<CookingStageListDto> result = _cookingStageService.GetPaginatedCookingStages(pagingParameters);

            var cookingStageListModels = result.Items.Select(x => _mapper.Map<CookingStageListModel>(x));

            return new PagedList<CookingStageListModel>(cookingStageListModels, result.TotalCount);
        }
    }
}

