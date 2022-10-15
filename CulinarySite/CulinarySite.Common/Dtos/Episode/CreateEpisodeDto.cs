
namespace CulinarySite.Common.Dtos.Episode
{
    public class CreateEpisodeDto 
    {
        public string Name { get; set; }
        public int CulinaryChannelId { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
