
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Restaurant
{
    public class CreateUpdateRestaurantBaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }
    }
}
