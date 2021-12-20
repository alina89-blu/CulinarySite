using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IRestaurantService
    {
        void CreateRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        IEnumerable<Restaurant> GetRestaurantListWithInclude();
        Restaurant GetRestaurantWithInclude(int id);
    }
}
