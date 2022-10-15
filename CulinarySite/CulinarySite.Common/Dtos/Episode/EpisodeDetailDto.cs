
namespace CulinarySite.Common.Dtos.Episode
{
    public class EpisodeDetailDto
    {
        public int EpisodeId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CulinaryChannelId { get; set; }
    }
}
