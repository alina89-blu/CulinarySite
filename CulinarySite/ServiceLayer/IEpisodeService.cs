using System.Collections.Generic;
using ServiceLayer.Dtos.Episode;

namespace ServiceLayer
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
