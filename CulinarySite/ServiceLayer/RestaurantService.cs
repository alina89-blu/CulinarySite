using System.Collections.Generic;
using Database;
using Repositories;
using ServiceLayer.ViewModels.Restaurant;
using ServiceLayer.ViewModels.Telephone;

namespace ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IReadOnlyGenericRepository<Restaurant> restaurantReadOnlyRepository;
        private readonly IWriteGenericRepository<Restaurant> restaurantWriteRepository;
        public RestaurantService(
            IReadOnlyGenericRepository<Restaurant> restaurantReadOnlyRepository,
            IWriteGenericRepository<Restaurant> restaurantWriteRepository)
        {
            this.restaurantReadOnlyRepository = restaurantReadOnlyRepository;
            this.restaurantWriteRepository = restaurantWriteRepository;
        }

        public void CreateRestaurant(CreateRestaurantModel createRestaurantModel)
        {
            var restaurant = new Restaurant
            {
                Name = createRestaurantModel.Name,
                AddressId = createRestaurantModel.AddressId
            };
            this.restaurantWriteRepository.Create(restaurant);
            this.restaurantWriteRepository.Save();
        }

        public void UpdateRestaurant(UpdateRestaurantModel updateRestaurantModel)
        {
            var restaurant = new Restaurant
            {
                Id = updateRestaurantModel.RestaurantId,
                Name = updateRestaurantModel.Name,
                AddressId = updateRestaurantModel.AddressId
            };
            this.restaurantWriteRepository.Update(restaurant);
            this.restaurantWriteRepository.Save();
        }

        public void DeleteRestaurant(int id)
        {
            this.restaurantWriteRepository.Delete(id);
            this.restaurantWriteRepository.Save();
        }

        public IEnumerable<RestaurantListModel> GetRestaurantList(bool withRelated)
        {
            IEnumerable<Restaurant> restaurants;
            List<RestaurantListModel> restaurantListModels = new List<RestaurantListModel>();
            if (withRelated)
            {
                restaurants = restaurantReadOnlyRepository.GetItemListWithInclude(
                   x => x.Telephones,
                   x => x.Address);
                foreach (var restaurant in restaurants)
                {
                    var telephones = new List<TelephoneDetailModel>();
                    foreach (var telephone in restaurant.Telephones)
                    {
                        telephones.Add(new TelephoneDetailModel
                        {
                            TelephoneId = telephone.Id,
                            Number = telephone.Number,
                            RestaurantId = restaurant.Id
                        });
                    }
                    restaurantListModels.Add(new RestaurantListModel
                    {
                        RestaurantId = restaurant.Id,
                        Name = restaurant.Name,
                        AddressName = restaurant.Address.Name,
                        Telephones = telephones
                    });
                }
                return restaurantListModels;
            }
            restaurants = this.restaurantReadOnlyRepository.GetItemList();
            foreach (var restaurant in restaurants)
            {
                restaurantListModels.Add(new RestaurantListModel
                {
                    RestaurantId = restaurant.Id,
                    Name = restaurant.Name
                });
            }
            return restaurantListModels;
        }

        public RestaurantDetailModel GetRestaurant(int id, bool withRelated)
        {
            var restaurant = new Restaurant();
            var restaurantDetailModel = new RestaurantDetailModel();


            if (withRelated)
            {
                restaurant = restaurantReadOnlyRepository.GetItemWithInclude(
                               x => x.Id == id,
                               x => x.Telephones,
                               x => x.Address);
                var telephones = new List<TelephoneDetailModel>();

                foreach (var telephone in restaurant.Telephones)
                {
                    telephones.Add(new TelephoneDetailModel
                    {
                        TelephoneId = telephone.Id,
                        Number = telephone.Number,
                        RestaurantId = restaurant.Id
                    });
                }
                restaurantDetailModel = new RestaurantDetailModel
                {
                    RestaurantId = restaurant.Id,
                    Name = restaurant.Name,
                    AddressId = restaurant.AddressId,
                    Telephones = telephones
                };
                return restaurantDetailModel;
            }
            restaurant = this.restaurantReadOnlyRepository.GetItem(id);
            restaurantDetailModel = new RestaurantDetailModel
            {
                RestaurantId = restaurant.Id,
                Name = restaurant.Name
            };
            return restaurantDetailModel;
        }
    }
}
