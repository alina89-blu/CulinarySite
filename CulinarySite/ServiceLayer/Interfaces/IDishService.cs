using CulinarySite.Common.Dtos.Dish;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
{
    public interface IDishService
    {
        void CreateDish(CreateDishDto createDishDto);
        void UpdateDish(UpdateDishDto updateDishDto);
        void DeleteDish(int id);
        DishDetailDto GetDish(int id, bool withRelated);
        IEnumerable<DishListDto> GetDishDetailList(bool withRelated);
        IEnumerable<DishDto> GetDishList();
    }
}
