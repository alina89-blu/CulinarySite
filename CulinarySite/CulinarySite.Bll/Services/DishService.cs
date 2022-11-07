using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Dish;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;
using CulinarySite.Common.Exceptions;

namespace CulinarySite.Bll.Services
{
    public class DishService : IDishService
    {
        private readonly IReadOnlyGenericRepository<Dish> _dishReadOnlyRepository;
        private readonly IWriteGenericRepository<Dish> _dishWriteRepository;
        private readonly IMapper _mapper;
        public DishService(
            IReadOnlyGenericRepository<Dish> dishReadOnlyRepository,
            IWriteGenericRepository<Dish> dishWriteRepository,
            IMapper mapper)
        {
            _dishReadOnlyRepository = dishReadOnlyRepository;
            _dishWriteRepository = dishWriteRepository;
            _mapper = mapper;
        }

        public void CreateDish(CreateDishDto createDishDto)
        {
            var dishCategories = _dishReadOnlyRepository.GetItemList().Select(x => x.Category);

            if (dishCategories.Contains(createDishDto.Category))
            {
                throw new ValidationException($"The dish category:{createDishDto.Category} already exists.");
            }

            Dish dish = _mapper.Map<Dish>(createDishDto);

            _dishWriteRepository.Create(dish);
            _dishWriteRepository.Save();
        }

        public void UpdateDish(UpdateDishDto updateDishDto)
        {
            Dish dish = _mapper.Map<Dish>(updateDishDto);

            _dishWriteRepository.Update(dish);
            _dishWriteRepository.Save();
        }

        public void DeleteDish(int id)
        {
            _dishWriteRepository.Delete(id);
            _dishWriteRepository.Save();
        }

        public DishDetailDto GetDish(int id, bool withRelated)
        {
            var dish = new Dish();
            var dishDetailDto = new DishDetailDto();

            if (withRelated)
            {
                dish = _dishReadOnlyRepository.GetItemWithInclude(
                                x => x.Id == id,
                                x => x.Recipes
                                );

                dishDetailDto = _mapper.Map<DishDetailDto>(dish);

                return dishDetailDto;
            }

            dish = _dishReadOnlyRepository.GetItem(id);
            dishDetailDto = _mapper.Map<DishDetailDto>(dish);

            return dishDetailDto;
        }

        public IEnumerable<DishListDto> GetDishDetailList(bool withRelated)
        {
            IEnumerable<Dish> dishes;
            IEnumerable<DishListDto> dishListDtos;

            if (withRelated)
            {
                dishes = _dishReadOnlyRepository.GetItemListWithInclude(x => x.Recipes);

                dishListDtos = dishes.Select(x => _mapper.Map<DishListDto>(x));

                return dishListDtos;
            }

            dishes = _dishReadOnlyRepository.GetItemList();

            dishListDtos = dishes.Select(x => _mapper.Map<DishListDto>(x));

            return dishListDtos;
        }

        public IEnumerable<DishDto> GetDishList()
        {
            IEnumerable<Dish> dishes = _dishReadOnlyRepository.GetItemList();
            var dishDtos = dishes.Select(x => _mapper.Map<DishDto>(x));

            return dishDtos;
        }
    }
}

