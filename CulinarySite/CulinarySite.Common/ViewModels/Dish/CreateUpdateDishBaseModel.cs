
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Dish
{
    public class CreateUpdateDishBaseModel
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
