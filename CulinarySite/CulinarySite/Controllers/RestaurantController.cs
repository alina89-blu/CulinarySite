using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Restaurant;

namespace CulinarySite.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RestaurantListModel> GetRestaurantList(bool withRelated)
        {
            return this.restaurantService.GetRestaurantList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public RestaurantDetailModel GetRestaurant(int id, bool withRelated)
        {
            return this.restaurantService.GetRestaurant(id,withRelated);
        }

        [HttpPost]
        public void CreateRestaurant(CreateRestaurantModel createRestaurantModel)
        {
            this.restaurantService.CreateRestaurant(createRestaurantModel);
        }

        [HttpPut]
        public void UpdateRestaurant(UpdateRestaurantModel updateRestaurantModel)
        {
            this.restaurantService.UpdateRestaurant(updateRestaurantModel);
        }

        [HttpDelete("{id}")]
        public void DeleteRestaurant(int id)
        {
            this.restaurantService.DeleteRestaurant(id);
        }
    }
}
