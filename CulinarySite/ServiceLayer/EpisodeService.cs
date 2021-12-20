using System.Collections.Generic;
using Database;
using Repositories;

namespace ServiceLayer
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IReadOnlyGenericRepository<Episode> episodeReadOnlyRepository;
        private readonly IWriteGenericRepository<Episode> episodeWriteRepository;
        public EpisodeService(
            IReadOnlyGenericRepository<Episode> episodeReadOnlyRepository,
            IWriteGenericRepository<Episode> episodeWriteRepository)
        {
            this.episodeReadOnlyRepository = episodeReadOnlyRepository;
            this.episodeWriteRepository = episodeWriteRepository;
        }

        public void CreateEpisode(Episode episode)
        {
            this.episodeWriteRepository.Create(episode);
            this.episodeWriteRepository.Save();
        }

        public void UpdateEpisode(Episode episode)
        {
            this.episodeWriteRepository.Update(episode);
            this.episodeWriteRepository.Save();
        }

        public void DeleteEpisode(int id)
        {
            this.episodeWriteRepository.Delete(id);
            this.episodeWriteRepository.Save();
        }

        public Episode GetEpisodeWithInclude(int id)
        {
            return this.episodeReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.CulinaryChannel,
                x => x.Image,
                x => x.Tags);
        }

        public IEnumerable<Episode> GetEpisodeListWithInclude()
        {
            return this.episodeReadOnlyRepository.GetItemListWithInclude(
                x => x.CulinaryChannel,
                x => x.Image,
                x => x.Tags);
        }
    }
}
