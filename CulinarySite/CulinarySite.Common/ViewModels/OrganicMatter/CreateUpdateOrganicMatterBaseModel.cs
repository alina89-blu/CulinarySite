
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.OrganicMatter
{
    public class CreateUpdateOrganicMatterBaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public double Quantity { get; set; }
    }
}
