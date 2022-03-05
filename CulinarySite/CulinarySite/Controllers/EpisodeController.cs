using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.Episode;

namespace CulinarySite.Controllers
{
    public class EpisodeController : BaseController
    {
        private readonly IEpisodeService episodeService;
        public EpisodeController(IEpisodeService episodeService)
        {
            this.episodeService = episodeService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<EpisodeListModel> GetEpisodeList(bool withRelated)
        {
            return this.episodeService.GetEpisodeList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public EpisodeDetailModel GetEpisode(int id, bool withRelated)
        {
            return this.episodeService.GetEpisode(id,withRelated);
        }

        [HttpPost]
        public void CreateEpisode(CreateEpisodeModel createEpisodeModel)
        {
            this.episodeService.CreateEpisode(createEpisodeModel);
        }

        [HttpPut]
        public void UpdateEpisode(UpdateEpisodeModel updateEpisodeModel)
        {
            this.episodeService.UpdateEpisode(updateEpisodeModel);
        }

        [HttpDelete("{id}")]
        public void DeleteEpisode(int id)
        {
            this.episodeService.DeleteEpisode(id);
        }
    }
}

