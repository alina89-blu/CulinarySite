using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurantListWithInclude()
        {
            return this.restaurantService.GetRestaurantListWithInclude();
        }

        [HttpGet("{id}")]
        public Restaurant GetRestaurantWithInclude(int id)
        {
            return this.restaurantService.GetRestaurantWithInclude(id);
        }

        [HttpPost]
        public void CreateRestaurant(Restaurant restaurant)
        {
            this.restaurantService.CreateRestaurant(restaurant);
        }

        [HttpPut]
        public void UpdateRestaurant(Restaurant restaurant)
        {
            this.restaurantService.UpdateRestaurant(restaurant);
        }

        [HttpDelete("{id}")]
        public void DeleteRestaurant(int id)
        {
            this.restaurantService.DeleteRestaurant(id);
        }
    }
}
