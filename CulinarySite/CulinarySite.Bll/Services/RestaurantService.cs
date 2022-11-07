using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Restaurant;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;
using CulinarySite.Common.Exceptions;

namespace CulinarySite.Bll.Services
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
            var restaurantNames = _restaurantReadOnlyRepository.GetItemList().Select(x => x.Name);

            if (restaurantNames.Contains(createRestaurantDto.Name))
            {
                throw new ValidationException($"The restaurant with name:{createRestaurantDto.Name} already exists.");
            }

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
            IEnumerable<RestaurantListDto> restaurantListDtos;
            if (withRelated)
            {
                restaurants = _restaurantReadOnlyRepository.GetItemListWithInclude(
                   x => x.Telephones,
                   x => x.Address,
                   x => x.Comments);
                restaurantListDtos = restaurants.Select(x => _mapper.Map<RestaurantListDto>(x));

                return restaurantListDtos;
            }

            restaurants = _restaurantReadOnlyRepository.GetItemList();
            restaurantListDtos = restaurants.Select(x => _mapper.Map<RestaurantListDto>(x));

            return restaurantListDtos;
        }

        public IEnumerable<RestaurantDto> GetRestaurantList()
        {
            IEnumerable<Restaurant> restaurants = _restaurantReadOnlyRepository.GetItemList();
            var restaurantDtos = restaurants.Select(x => _mapper.Map<RestaurantDto>(x));

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
