using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace CulinarySite.Controllers
{
    public class EpisodeController : BaseController
    {
        private readonly IEpisodeService episodeService;
        public EpisodeController(IEpisodeService episodeService)
        {
            this.episodeService = episodeService;
        }
        [HttpGet]
        public IEnumerable<Episode> GetEpisodeListWithInclude()
        {
            return this.episodeService.GetEpisodeListWithInclude();
        }

        [HttpGet("{id}")]
        public Episode GetEpisodeWithInclude(int id)
        {
            return this.episodeService.GetEpisodeWithInclude(id);
        }

        [HttpPost]
        public void CreateEpisode(Episode episode)
        {
            this.episodeService.CreateEpisode(episode);
        }

        [HttpPut]
        public void UpdateEpisode(Episode episode)
        {
            this.episodeService.UpdateEpisode(episode);
        }

        [HttpDelete("{id}")]
        public void DeleteEpisode(int id)
        {
            this.episodeService.DeleteEpisode(id);
        }
    }

}

