using System.Collections.Generic;
using Repositories;
using Database;
using AutoMapper;
using ServiceLayer.Dtos.Dish;

namespace ServiceLayer
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
                                x => x.Recipes,
                                x => x.Image);

                dishDetailDto = _mapper.Map<DishDetailDto>(dish);

                return dishDetailDto;
            }

            dish = _dishReadOnlyRepository.GetItem(id);
            dishDetailDto = _mapper.Map<DishDetailDto>(dish);

            return dishDetailDto;
        }

        public IEnumerable<DishListDto> GetDishList(bool withRelated)
        {
            IEnumerable<Dish> dishes;
            var dishListDtos = new List<DishListDto>();

            if (withRelated)
            {
                dishes = _dishReadOnlyRepository.GetItemListWithInclude(
                    x => x.Recipes,
                    x => x.Image);

                foreach (var dish in dishes)
                {
                    dishListDtos.Add(_mapper.Map<DishListDto>(dish));
                }
                return dishListDtos;
            }
            dishes = _dishReadOnlyRepository.GetItemList();

            foreach (var dish in dishes)
            {
                dishListDtos.Add(_mapper.Map<DishListDto>(dish));
            }
            return dishListDtos;
        }
    }
}

