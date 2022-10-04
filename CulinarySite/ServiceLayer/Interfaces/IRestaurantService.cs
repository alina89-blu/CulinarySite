using CulinarySite.Common.Dtos.Restaurant;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
{
    public interface IRestaurantService
    {
        void CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        void UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto);
        void DeleteRestaurant(int id);
        IEnumerable<RestaurantListDto> GetRestaurantDetailList(bool withRelated);
        IEnumerable<RestaurantDto> GetRestaurantList();
        RestaurantDetailDto GetRestaurant(int id, bool withRelated);
    }
}
