using System.Collections.Generic;
using AutoMapper;
using Database;
using Repositories;
using ServiceLayer.Dtos.Episode;

namespace ServiceLayer
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IReadOnlyGenericRepository<Episode> _episodeReadOnlyRepository;
        private readonly IWriteGenericRepository<Episode> _episodeWriteRepository;
        private readonly IMapper _mapper;
        public EpisodeService(
            IReadOnlyGenericRepository<Episode> episodeReadOnlyRepository,
            IWriteGenericRepository<Episode> episodeWriteRepository,
            IMapper mapper)
        {
            _episodeReadOnlyRepository = episodeReadOnlyRepository;
            _episodeWriteRepository = episodeWriteRepository;
            _mapper = mapper;
        }

        public void CreateEpisode(CreateEpisodeDto createEpisodeDto)
        {
            Episode episode = _mapper.Map<Episode>(createEpisodeDto);

            _episodeWriteRepository.Create(episode);
            _episodeWriteRepository.Save();
        }

        public void UpdateEpisode(UpdateEpisodeDto updateEpisodeDto)
        {
            Episode episode = _mapper.Map<Episode>(updateEpisodeDto);

            _episodeWriteRepository.Update(episode);
            _episodeWriteRepository.Save();
        }

        public void DeleteEpisode(int id)
        {
            _episodeWriteRepository.Delete(id);
            _episodeWriteRepository.Save();
        }

        public EpisodeDetailDto GetEpisode(int id, bool withRelated)
        {
            var episode = new Episode();
            var episodeDetailDto = new EpisodeDetailDto();

            if (withRelated)
            {
                episode = _episodeReadOnlyRepository.GetItemWithInclude(
                                x => x.Id == id,
                                x => x.CulinaryChannel,
                                x => x.Image,
                                x => x.Tags
                               );

                episodeDetailDto = _mapper.Map<EpisodeDetailDto>(episode);

                return episodeDetailDto;
            }

            episode = _episodeReadOnlyRepository.GetItem(id);
            episodeDetailDto = _mapper.Map<EpisodeDetailDto>(episode);

            return episodeDetailDto;
        }

        public IEnumerable<EpisodeListDto> GetEpisodeList(bool withRelated)
        {
            IEnumerable<Episode> episodes;
            var episodeListDtos = new List<EpisodeListDto>();

            if (withRelated)
            {
                episodes = _episodeReadOnlyRepository.GetItemListWithInclude(
                                x => x.CulinaryChannel,
                                x => x.Image,
                                x => x.Tags);

                foreach (var episode in episodes)
                {
                    episodeListDtos.Add(_mapper.Map<EpisodeListDto>(episode));
                }
                return episodeListDtos;
            }
            episodes = _episodeReadOnlyRepository.GetItemList();

            foreach (var episode in episodes)
            {
                episodeListDtos.Add(_mapper.Map<EpisodeListDto>(episode));
            }
            return episodeListDtos;
        }
    }
}
