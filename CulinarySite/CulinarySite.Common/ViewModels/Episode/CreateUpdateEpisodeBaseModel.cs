
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Episode
{
    public class CreateUpdateEpisodeBaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CulinaryChannelId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string VideoUrl { get; set; }
    }
}
