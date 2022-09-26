
using ServiceLayer.ViewModels.Image.DishImage;

namespace ServiceLayer.ViewModels.Dish
{
    public class DishListModel
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        public DishImageModel Image { get; set; }
    }
}
