using System.Collections.Generic;
using ServiceLayer.ViewModels.Dish;

namespace ServiceLayer
{
    public interface IDishService
    {
        void CreateDish(CreateDishModel createDishModel);
        void UpdateDish(UpdateDishModel updateDishModel);
        void DeleteDish(int id);
        DishDetailModel GetDish(int id, bool withRelated);
        IEnumerable<DishListModel> GetDishList(bool withRelated);
    }
}
