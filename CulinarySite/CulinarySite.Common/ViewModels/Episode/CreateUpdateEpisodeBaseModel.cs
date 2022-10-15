
namespace CulinarySite.Common.ViewModels.Episode
{
    public class CreateUpdateEpisodeBaseModel
    {
        public string Name { get; set; }
        public int CulinaryChannelId { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
