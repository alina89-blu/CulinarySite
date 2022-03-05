using System.Collections.Generic;
using Repositories;
using Database;
using ServiceLayer.ViewModels.Dish;

namespace ServiceLayer
{
    public class DishService : IDishService
    {
        private readonly IReadOnlyGenericRepository<Dish> dishReadOnlyRepository;
        private readonly IWriteGenericRepository<Dish> dishWriteRepository;
        public DishService(
            IReadOnlyGenericRepository<Dish> dishReadOnlyRepository,
            IWriteGenericRepository<Dish> dishWriteRepository)
        {
            this.dishReadOnlyRepository = dishReadOnlyRepository;
            this.dishWriteRepository = dishWriteRepository;
        }

        public void CreateDish(CreateDishModel createDishModel)
        {
            var dish = new Dish()
            {
                Category = createDishModel.Category
            };

            this.dishWriteRepository.Create(dish);
            this.dishWriteRepository.Save();
        }

        public void UpdateDish(UpdateDishModel updateDishModel)
        {
            var dish = new Dish()
            {
                Id=updateDishModel.DishId,
                Category = updateDishModel.Category
            };
            this.dishWriteRepository.Update(dish);
            this.dishWriteRepository.Save();
        }

        public void DeleteDish(int id)
        {
            this.dishWriteRepository.Delete(id);
            this.dishWriteRepository.Save();
        }

        public DishDetailModel GetDish(int id, bool withRelated)
        {
            var dish = new Dish();
            DishDetailModel dishDetailModel = new DishDetailModel();
            if (withRelated)
            {
                dish = this.dishReadOnlyRepository.GetItemWithInclude(
                                x => x.Id == id);
                dishDetailModel = new DishDetailModel
                {
                    DishId = dish.Id,
                    Category = dish.Category
                };
                return dishDetailModel;
            }
            dish = this.dishReadOnlyRepository.GetItem(id);
            dishDetailModel = new DishDetailModel
            {
                DishId = dish.Id,
                Category = dish.Category
            };
            return dishDetailModel;
        }

        public IEnumerable<DishListModel> GetDishList(bool withRelated)
        {
            IEnumerable<Dish> dishes;
            List<DishListModel> dishListModels = new List<DishListModel>();
            if (withRelated)
            {
                dishes = this.dishReadOnlyRepository.GetItemListWithInclude();
                foreach (var dish in dishes)
                {
                    dishListModels.Add(new DishListModel
                    {
                        DishId = dish.Id,
                        Category = dish.Category
                    });
                }
                return dishListModels;
            }
            dishes = this.dishReadOnlyRepository.GetItemList();
            foreach (var dish in dishes)
            {
                dishListModels.Add(new DishListModel
                {
                    DishId = dish.Id,
                    Category = dish.Category
                });
            }
            return dishListModels;
        }
    }
}

