using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Dish;
using AutoMapper;
using ServiceLayer.Dtos.Dish;

namespace CulinarySite.Controllers
{
    public class DishController : BaseController
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;
        public DishController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<DishListModel> GetDishList(bool withRelated)
        {
            IEnumerable<DishListDto> dishListDtos = _dishService.GetDishList(withRelated);
            var dishListModels = new List<DishListModel>();

            foreach (var dishListDto in dishListDtos)
            {
                dishListModels.Add(_mapper.Map<DishListModel>(dishListDto));
            }
            return dishListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public DishDetailModel GetDish(int id, bool withRelated)
        {
            DishDetailDto dishDetailDto = _dishService.GetDish(id, withRelated);
            DishDetailModel dishDetailModel = _mapper.Map<DishDetailModel>(dishDetailDto);

            return dishDetailModel;
        }

        [HttpPost]
        public void CreateDish(CreateDishModel createDishModel)
        {
            CreateDishDto createDishDto = _mapper.Map<CreateDishDto>(createDishModel);
            _dishService.CreateDish(createDishDto);
        }

        [HttpPut]
        public void UpdateDish(UpdateDishModel updateDishModel)
        {
            UpdateDishDto updateDishDto = _mapper.Map<UpdateDishDto>(updateDishModel);
            _dishService.UpdateDish(updateDishDto);
        }

        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            _dishService.DeleteDish(id);
        }
    }
}
