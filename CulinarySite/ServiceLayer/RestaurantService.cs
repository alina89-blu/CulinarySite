using System.Collections.Generic;
using AutoMapper;
using Database.Entities;
using Repositories;
using ServiceLayer.Dtos.Restaurant;

namespace ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IReadOnlyGenericRepository<Restaurant> _restaurantReadOnlyRepository;
        private readonly IWriteGenericRepository<Restaurant> _restaurantWriteRepository;
        private readonly IMapper _mapper;
        public RestaurantService(
            IReadOnlyGenericRepository<Restaurant> restaurantReadOnlyRepository,
            IWriteGenericRepository<Restaurant> restaurantWriteRepository,
            IMapper mapper)
        {
            _restaurantReadOnlyRepository = restaurantReadOnlyRepository;
            _restaurantWriteRepository = restaurantWriteRepository;
            _mapper = mapper;
        }

        public void CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            Restaurant restaurant = _mapper.Map<Restaurant>(createRestaurantDto);

            _restaurantWriteRepository.Create(restaurant);
            _restaurantWriteRepository.Save();
        }

        public void UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto)
        {
            Restaurant restaurant = _mapper.Map<Restaurant>(updateRestaurantDto);

            _restaurantWriteRepository.Update(restaurant);
            _restaurantWriteRepository.Save();
        }

        public void DeleteRestaurant(int id)
        {
            _restaurantWriteRepository.Delete(id);
            _restaurantWriteRepository.Save();
        }

        public IEnumerable<RestaurantListDto> GetRestaurantDetailList(bool withRelated)
        {
            IEnumerable<Restaurant> restaurants;
            var restaurantListDtos = new List<RestaurantListDto>();
            if (withRelated)
            {
                restaurants = _restaurantReadOnlyRepository.GetItemListWithInclude(
                   x => x.Telephones,
                   x => x.Address,
                   x => x.Comments);

                foreach (var restaurant in restaurants)
                {
                    restaurantListDtos.Add(_mapper.Map<RestaurantListDto>(restaurant));
                }

                return restaurantListDtos;
            }

            restaurants = _restaurantReadOnlyRepository.GetItemList();

            foreach (var restaurant in restaurants)
            {
                restaurantListDtos.Add(_mapper.Map<RestaurantListDto>(restaurant));
            }

            return restaurantListDtos;
        }

        public IEnumerable<RestaurantDto> GetRestaurantList()
        {            
            IEnumerable<Restaurant> restaurants = _restaurantReadOnlyRepository.GetItemList();

            var restaurantDtos = new List<RestaurantDto>();

            foreach (var restaurant in restaurants)
            {
                restaurantDtos.Add(_mapper.Map<RestaurantDto>(restaurant));
            }

            return restaurantDtos;
        }

        public RestaurantDetailDto GetRestaurant(int id, bool withRelated)
        {
            var restaurant = new Restaurant();
            var restaurantDetailDto = new RestaurantDetailDto();

            if (withRelated)
            {
                restaurant = _restaurantReadOnlyRepository.GetItemWithInclude(
                               x => x.Id == id,
                               x => x.Telephones,
                               x => x.Address,
                               x => x.Comments);

                restaurantDetailDto = _mapper.Map<RestaurantDetailDto>(restaurant);

                return restaurantDetailDto;
            }

            restaurant = _restaurantReadOnlyRepository.GetItem(id);

            restaurantDetailDto = _mapper.Map<RestaurantDetailDto>(restaurant);

            return restaurantDetailDto;
        }
    }
}
