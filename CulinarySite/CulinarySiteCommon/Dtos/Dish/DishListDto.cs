
using ServiceLayer.Dtos.Image.DishImage;

namespace CulinarySite.Common.Dtos.Dish
{
    public class DishListDto
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        public DishImageDto Image { get; set; }
    }
}
