using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Dish;
using CulinarySite.Common.Dtos.Dish;
using CulinarySite.Bll.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CulinarySite.Api.Controllers
{
    public class DishController : ApiController
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;
        public DishController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<DishListModel> GetDishDetailList(bool withRelated)
        {
            IEnumerable<DishListDto> dishListDtos = _dishService.GetDishDetailList(withRelated);
            var dishListModels = dishListDtos.Select(x => _mapper.Map<DishListModel>(x));

            return dishListModels;
        }

        [HttpGet]
        public IEnumerable<DishModel> GetDishList()
        {
            IEnumerable<DishDto> dishDtos = _dishService.GetDishList();
            var dishModels = dishDtos.Select(x => _mapper.Map<DishModel>(x));

            return dishModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public DishDetailModel GetDish(int id, bool withRelated)
        {
            DishDetailDto dishDetailDto = _dishService.GetDish(id, withRelated);
            DishDetailModel dishDetailModel = _mapper.Map<DishDetailModel>(dishDetailDto);

            return dishDetailModel;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public void CreateDish(CreateDishModel createDishModel)
        {
            CreateDishDto createDishDto = _mapper.Map<CreateDishDto>(createDishModel);
            _dishService.CreateDish(createDishDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public void UpdateDish(UpdateDishModel updateDishModel)
        {
            UpdateDishDto updateDishDto = _mapper.Map<UpdateDishDto>(updateDishModel);
            _dishService.UpdateDish(updateDishDto);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            _dishService.DeleteDish(id);
        }
    }
}
