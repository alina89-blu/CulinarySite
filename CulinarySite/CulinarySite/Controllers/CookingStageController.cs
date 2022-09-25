using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.ViewModels.CookingStage;

namespace CulinarySite.Controllers
{
    public class CookingStageController : BaseController
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
            var cookingStageListModels = new List<CookingStageListModel>();

            foreach(var cookingStageListDto in cookingStageListDtos)
            {
                cookingStageListModels.Add(_mapper.Map<CookingStageListModel>(cookingStageListDto));
            }

            return cookingStageListModels;
        }
       
        [HttpGet("{id}/{withRelated}")]
        public CookingStageDetailModel GetCookingStage(int id, bool withRelated)
        {
            CookingStageDetailDto cookingStageDetailDto= _cookingStageService.GetCookingStage(id, withRelated);
            CookingStageDetailModel cookingStageDetailModel = _mapper.Map<CookingStageDetailModel>(cookingStageDetailDto);

            return cookingStageDetailModel;
        }

        [HttpPost]
        public void CreateCookingStage(CreateCookingStageModel createCookingStageModel)
        {
            var createCookingStageDto = _mapper.Map<CreateCookingStageDto>(createCookingStageModel);
            _cookingStageService.CreateCookingStage(createCookingStageDto);
        }

        [HttpPut]
        public void UpdateCookingStage(UpdateCookingStageModel updateCookingStageModel)
        {
            var updateCookingStageDto = _mapper.Map<UpdateCookingStageDto>(updateCookingStageModel);
            _cookingStageService.UpdateCookingStage(updateCookingStageDto);
        }

        [HttpDelete("{id}")]
        public void DeleteCookingStage(int id)
        {
            _cookingStageService.DeleteCookingStage(id);
        }
    }
}

