using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Restaurant;
using CulinarySite.Common.Dtos.Restaurant;
using CulinarySite.Bll.Interfaces;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RestaurantListModel> GetRestaurantDetailList(bool withRelated)
        {
            IEnumerable<RestaurantListDto> restaurantListDtos = _restaurantService.GetRestaurantDetailList(withRelated);
            var restaurantListModels = restaurantListDtos.Select(x => _mapper.Map<RestaurantListModel>(x));
            
            return restaurantListModels;
        }

        [HttpGet]
        public IEnumerable<RestaurantModel> GetRestaurantList()
        {
            IEnumerable<RestaurantDto> restaurantDtos = _restaurantService.GetRestaurantList();
            var restaurantModels = restaurantDtos.Select(x => _mapper.Map<RestaurantModel>(x));

            return restaurantModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public RestaurantDetailModel GetRestaurant(int id, bool withRelated)
        {
            RestaurantDetailDto restaurantDetailDto = _restaurantService.GetRestaurant(id, withRelated);
            RestaurantDetailModel restaurantDetailModel = _mapper.Map<RestaurantDetailModel>(restaurantDetailDto);

            return restaurantDetailModel;
        }

        [HttpPost]
        public void CreateRestaurant(CreateRestaurantModel createRestaurantModel)
        {
            CreateRestaurantDto createRestaurantDto = _mapper.Map<CreateRestaurantDto>(createRestaurantModel);
            _restaurantService.CreateRestaurant(createRestaurantDto);
        }

        [HttpPut]
        public void UpdateRestaurant(UpdateRestaurantModel updateRestaurantModel)
        {
            UpdateRestaurantDto updateRestaurantDto = _mapper.Map<UpdateRestaurantDto>(updateRestaurantModel);
            _restaurantService.UpdateRestaurant(updateRestaurantDto);
        }

        [HttpDelete("{id}")]
        public void DeleteRestaurant(int id)
        {
            _restaurantService.DeleteRestaurant(id);
        }
    }
}
