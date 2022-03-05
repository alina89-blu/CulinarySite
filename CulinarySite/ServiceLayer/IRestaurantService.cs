using System.Collections.Generic;
using ServiceLayer.ViewModels.Restaurant;

namespace ServiceLayer
{
    public interface IRestaurantService
    {
        void CreateRestaurant(CreateRestaurantModel createRestaurantModel);
        void UpdateRestaurant(UpdateRestaurantModel updateRestaurantModel);
        void DeleteRestaurant(int id);
        IEnumerable<RestaurantListModel> GetRestaurantList(bool withRelated);
        RestaurantDetailModel GetRestaurant(int id, bool withRelated);
    }
}
