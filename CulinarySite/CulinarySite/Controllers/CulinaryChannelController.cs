using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.CulinaryChannel;

namespace CulinarySite.Controllers
{
    public class CulinaryChannelController : BaseController
    {
        private readonly ICulinaryChannelService culinaryChannelService;
        public CulinaryChannelController(ICulinaryChannelService culinaryChannelService)
        {
            this.culinaryChannelService = culinaryChannelService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<CulinaryChannelListModel> GetCulinaryChannelList(bool withRelated)
        {
            return this.culinaryChannelService.GetCulinaryChannelList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public CulinaryChannelDetailModel GetCulinaryChannel(int id, bool withRelated)
        {
            return this.culinaryChannelService.GetCulinaryChannel(id,withRelated);
        }

        [HttpPost]
        public void CreateCulinaryChannel(CreateCulinaryChannelModel createCulinaryChannelModel)
        {
            this.culinaryChannelService.CreateCulinaryChannel(createCulinaryChannelModel);
        }

        [HttpPut]
        public void UpdateCulinaryChannel(UpdateCulinaryChannelModel updateCulinaryChannelModel)
        {
            this.culinaryChannelService.UpdateCulinaryChannel(updateCulinaryChannelModel);
        }

        [HttpDelete("{id}")]
        public void DeleteCulinaryChannel(int id)
        {
            this.culinaryChannelService.DeleteCulinaryChannel(id);
        }
    }
}

