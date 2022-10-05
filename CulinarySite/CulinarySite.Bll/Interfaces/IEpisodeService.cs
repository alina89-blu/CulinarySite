using CulinarySite.Common.Dtos.Episode;
using System.Collections.Generic;
namespace CulinarySite.Bll.Interfaces
{
    public interface IEpisodeService
    {
        void CreateEpisode(CreateEpisodeDto createEpisodeDto);
        void UpdateEpisode(UpdateEpisodeDto updateEpisodeDto);
        void DeleteEpisode(int id);
        EpisodeDetailDto GetEpisode(int id,bool withRelated);
        IEnumerable<EpisodeListDto> GetEpisodeList(bool withRelated);
    }
}
