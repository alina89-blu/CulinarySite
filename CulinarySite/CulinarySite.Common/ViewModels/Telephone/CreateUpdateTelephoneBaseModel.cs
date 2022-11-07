
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Telephone
{
    public class CreateUpdateTelephoneBaseModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}
