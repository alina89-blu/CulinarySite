using System.Collections.Generic;
using Database;
using Repositories;

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

        public void CreateRestaurant(Restaurant restaurant)
        {
            this.restaurantWriteRepository.Create(restaurant);
            this.restaurantWriteRepository.Save();
        }
        public void UpdateRestaurant(Restaurant restaurant)
        {
            this.restaurantWriteRepository.Update(restaurant);
            this.restaurantWriteRepository.Save();
        }
        public void DeleteRestaurant(int id)
        {
            this.restaurantWriteRepository.Delete(id);
            this.restaurantWriteRepository.Save();
        }
        public IEnumerable<Restaurant> GetRestaurantListWithInclude()
        {
            return restaurantReadOnlyRepository.GetItemListWithInclude(
                x => x.Telephones,
                x => x.Comments,
                x => x.Address);
        }
        public Restaurant GetRestaurantWithInclude(int id)
        {
            return restaurantReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Telephones,
                x => x.Comments,
                x => x.Address);
        }
    }
}
