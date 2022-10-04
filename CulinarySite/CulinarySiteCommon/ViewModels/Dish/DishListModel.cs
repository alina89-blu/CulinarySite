
using ServiceLayer.ViewModels.Image.DishImage;

namespace CulinarySite.Common.ViewModels.Dish
{
    public class DishListModel
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        public DishImageModel Image { get; set; }
    }
}
