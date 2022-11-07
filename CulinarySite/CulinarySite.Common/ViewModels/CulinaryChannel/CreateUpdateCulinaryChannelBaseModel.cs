
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.CulinaryChannel
{
    public class CreateUpdateCulinaryChannelBaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
