
namespace CulinarySite.Common.Dtos.Episode
{
    public class UpdateEpisodeDto 
    {
        public int EpisodeId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CulinaryChannelId { get; set; }
    }
}
