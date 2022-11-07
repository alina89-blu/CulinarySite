
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Address
{
    public class CreateUpdateAddressBaseModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
