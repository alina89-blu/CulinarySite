using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface IEpisodeService
    {
        void CreateEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
        void DeleteEpisode(int id);
        Episode GetEpisodeWithInclude(int id);
        IEnumerable<Episode> GetEpisodeListWithInclude();
    }
}
