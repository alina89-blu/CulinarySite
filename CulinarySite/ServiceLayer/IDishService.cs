using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface IDishService
    {
        void CreateDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(int id);
        Dish GetDishWithInclude(int id);
        IEnumerable<Dish> GetDishListWithInclude();
    }
}
