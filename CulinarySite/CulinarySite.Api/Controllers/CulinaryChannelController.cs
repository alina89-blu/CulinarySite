﻿using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.CulinaryChannel;
using CulinarySite.Common.ViewModels.CulinaryChannel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class CulinaryChannelController : ApiController
    {
        private readonly ICulinaryChannelService _culinaryChannelService;
        private readonly IMapper _mapper;
        public CulinaryChannelController(ICulinaryChannelService culinaryChannelService, IMapper mapper)
        {
            _culinaryChannelService = culinaryChannelService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<CulinaryChannelListModel> GetCulinaryChannelList(bool withRelated)
        {
            IEnumerable<CulinaryChannelListDto> culinaryChannelListDtos = _culinaryChannelService.GetCulinaryChannelList(withRelated);
            var culinaryChannelListModels = culinaryChannelListDtos.Select(x => _mapper.Map<CulinaryChannelListModel>(x));
           
            return culinaryChannelListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public CulinaryChannelDetailModel GetCulinaryChannel(int id, bool withRelated)
        {
            CulinaryChannelDetailDto culinaryChannelDetailDto = _culinaryChannelService.GetCulinaryChannel(id, withRelated);
            CulinaryChannelDetailModel culinaryChannelDetailModel = _mapper.Map<CulinaryChannelDetailModel>(culinaryChannelDetailDto);

            return culinaryChannelDetailModel;
        }

        [HttpPost]
        public void CreateCulinaryChannel(CreateCulinaryChannelModel createCulinaryChannelModel)
        {
            var createCulinaryChannelDto = _mapper.Map<CreateCulinaryChannelDto>(createCulinaryChannelModel);
            _culinaryChannelService.CreateCulinaryChannel(createCulinaryChannelDto);
        }

        [HttpPut]
        public void UpdateCulinaryChannel(UpdateCulinaryChannelModel updateCulinaryChannelModel)
        {
            var updateCulinaryChannelDto = _mapper.Map<UpdateCulinaryChannelDto>(updateCulinaryChannelModel);
            _culinaryChannelService.UpdateCulinaryChannel(updateCulinaryChannelDto);
        }

        [HttpDelete("{id}")]
        public void DeleteCulinaryChannel(int id)
        {
            _culinaryChannelService.DeleteCulinaryChannel(id);
        }
    }
}
