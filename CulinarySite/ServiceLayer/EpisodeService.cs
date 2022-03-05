using System.Collections.Generic;
using Database;
using Repositories;
using ServiceLayer.ViewModels.Episode;

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

        public void CreateEpisode(CreateEpisodeModel createEpisodeModel)
        {
            var episode = new Episode
            {
                Name = createEpisodeModel.Name,
                CulinaryChannelId = createEpisodeModel.CulinaryChannelId
            };
            this.episodeWriteRepository.Create(episode);
            this.episodeWriteRepository.Save();
        }

        public void UpdateEpisode(UpdateEpisodeModel updateEpisodeModel)
        {
            var episode = new Episode
            {
                Id = updateEpisodeModel.EpisodeId,
                Name = updateEpisodeModel.Name,
                CulinaryChannelId = updateEpisodeModel.CulinaryChannelId
            };
            this.episodeWriteRepository.Update(episode);
            this.episodeWriteRepository.Save();
        }

        public void DeleteEpisode(int id)
        {
            this.episodeWriteRepository.Delete(id);
            this.episodeWriteRepository.Save();
        }

        public EpisodeDetailModel GetEpisode(int id, bool withRelated)
        {
            var episode = new Episode();
            EpisodeDetailModel episodeDetailModel = new EpisodeDetailModel();
            if (withRelated)
            {
                episode = this.episodeReadOnlyRepository.GetItemWithInclude(
                                x => x.Id == id,
                                x => x.CulinaryChannel
                               );
                episodeDetailModel = new EpisodeDetailModel
                {
                    EpisodeId = episode.Id,
                    Name = episode.Name,
                    CulinaryChannelId = episode.CulinaryChannelId
                };
                return episodeDetailModel;
            }

            episode = this.episodeReadOnlyRepository.GetItem(id);
            episodeDetailModel = new EpisodeDetailModel
            {
                EpisodeId = episode.Id,
                Name = episode.Name,
            };
            return episodeDetailModel;
        }

        public IEnumerable<EpisodeListModel> GetEpisodeList(bool withRelated)
        {
            IEnumerable<Episode> episodes;
            List<EpisodeListModel> episodeListModels = new List<EpisodeListModel>();
            if (withRelated)
            {
                episodes = this.episodeReadOnlyRepository.GetItemListWithInclude(
                                x => x.CulinaryChannel);
                foreach (var episode in episodes)
                {
                    episodeListModels.Add(new EpisodeListModel
                    {
                        EpisodeId = episode.Id,
                        Name = episode.Name,
                        CulinaryChannelName = episode.CulinaryChannel.Name
                    });
                }
                return episodeListModels;
            }
            episodes = this.episodeReadOnlyRepository.GetItemList();
            foreach (var episode in episodes)
            {
                episodeListModels.Add(new EpisodeListModel
                {
                    EpisodeId = episode.Id,
                    Name = episode.Name                    
                });
            }
            return episodeListModels;
        }
    }
}
