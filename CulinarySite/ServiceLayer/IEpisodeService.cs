using System.Collections.Generic;
using ServiceLayer.ViewModels.Episode;

namespace ServiceLayer
{
    public interface IEpisodeService
    {
        void CreateEpisode(CreateEpisodeModel createEpisodeModel);
        void UpdateEpisode(UpdateEpisodeModel updateEpisodeModel);
        void DeleteEpisode(int id);
        EpisodeDetailModel GetEpisode(int id,bool withRelated);
        IEnumerable<EpisodeListModel> GetEpisodeList(bool withRelated);
    }
}
