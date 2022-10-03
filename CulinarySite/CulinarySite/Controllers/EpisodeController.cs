using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Dtos.Episode;
using ServiceLayer.ViewModels.Episode;

namespace CulinaryApi.Controllers
{
    public class EpisodeController : ApiController
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;
        public EpisodeController(IEpisodeService episodeService, IMapper mapper)
        {
            _episodeService = episodeService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<EpisodeListModel> GetEpisodeList(bool withRelated)
        {
            IEnumerable<EpisodeListDto> episodeListDtos = _episodeService.GetEpisodeList(withRelated);
            var episodeListModels = new List<EpisodeListModel>();

            foreach (var episodeListDto in episodeListDtos)
            {
                episodeListModels.Add(_mapper.Map<EpisodeListModel>(episodeListDto));
            }

            return episodeListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public EpisodeDetailModel GetEpisode(int id, bool withRelated)
        {
            EpisodeDetailDto episodeDetailDto = _episodeService.GetEpisode(id, withRelated);
            EpisodeDetailModel episodeDetailModel = _mapper.Map<EpisodeDetailModel>(episodeDetailDto);

            return episodeDetailModel;
        }

        [HttpPost]
        public void CreateEpisode(CreateEpisodeModel createEpisodeModel)
        {
            CreateEpisodeDto createEpisodeDto = _mapper.Map<CreateEpisodeDto>(createEpisodeModel);
            _episodeService.CreateEpisode(createEpisodeDto);
        }

        [HttpPut]
        public void UpdateEpisode(UpdateEpisodeModel updateEpisodeModel)
        {
            UpdateEpisodeDto updateEpisodeDto = _mapper.Map<UpdateEpisodeDto>(updateEpisodeModel);
            _episodeService.UpdateEpisode(updateEpisodeDto);
        }

        [HttpDelete("{id}")]
        public void DeleteEpisode(int id)
        {
            _episodeService.DeleteEpisode(id);
        }
    }
}

