using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Database;

namespace CulinarySite.Controllers
{
    public class CulinaryChannelController : BaseController
    {
        private readonly ICulinaryChannelService culinaryChannelService;
        public CulinaryChannelController(ICulinaryChannelService culinaryChannelService)
        {
            this.culinaryChannelService = culinaryChannelService;
        }

        [HttpGet]
        public IEnumerable<CulinaryChannel> GetCulinaryChannelListWithInclude()
        {
            return this.culinaryChannelService.GetCulinaryChannelListWithInclude();
        }

        [HttpGet("{id}")]
        public CulinaryChannel GetCulinaryChannelWithInclude(int id)
        {
            return this.culinaryChannelService.GetCulinaryChannelWithInclude(id);
        }

        [HttpPost]
        public void CreateCulinaryChannel(CulinaryChannel culinaryChannel)
        {
            this.culinaryChannelService.CreateCulinaryChannel(culinaryChannel);
        }

        [HttpPut]
        public void UpdateCulinaryChannel(CulinaryChannel culinaryChannel)
        {
            this.culinaryChannelService.UpdateCulinaryChannel(culinaryChannel);
        }

        [HttpDelete("{id}")]
        public void DeleteCulinaryChannel(int id)
        {
            this.culinaryChannelService.DeleteCulinaryChannel(id);
        }
    }
}

