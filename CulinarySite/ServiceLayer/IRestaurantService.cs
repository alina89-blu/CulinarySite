using System.Collections.Generic;
using ServiceLayer.Dtos.Restaurant;

namespace ServiceLayer
{
    public interface IRestaurantService
    {
        void CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        void UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto);
        void DeleteRestaurant(int id);
        IEnumerable<RestaurantListDto> GetRestaurantList(bool withRelated);
        RestaurantDetailDto GetRestaurant(int id, bool withRelated);
    }
}
