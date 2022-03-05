using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ViewModels.Image.DishImage;
using ServiceLayer.ViewModels.Image.EpisodeImage;


namespace CulinarySite.Controllers
{
    public class ImageController : BaseController
    {
        private readonly IImageService imageService;
        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet("{withRelated}/dish")]
        public IEnumerable<DishImageListModel> GetDishImageList(bool withRelated)
        {
            return this.imageService.GetDishImageList(withRelated);
        }

        [HttpGet("{id}/{withRelated}/dish")]
        public DishImageDetailModel GetDishImage(int id, bool withRelated)
        {
            return this.imageService.GetDishImage(id, withRelated);
        }

        [HttpPost("dish")]
        public void CreateDishImage(CreateDishImageModel createDishImageModel)
        {
            this.imageService.CreateDishImage(createDishImageModel);
        }

        [HttpPut("dish")]
        public void UpdateDishImage(UpdateDishImageModel updateDishImageModel)
        {
            this.imageService.UpdateDishImage(updateDishImageModel);
        }       

        [HttpGet("{withRelated}/episode")]
        public IEnumerable<EpisodeImageListModel> GetEpisodeImageList(bool withRelated)
        {
            return this.imageService.GetEpisodeImageList(withRelated);
        }

        [HttpGet("{id}/{withRelated}/episode")]
        public EpisodeImageDetailModel GetEpisodeImage(int id, bool withRelated)
        {
            return this.imageService.GetEpisodeImage(id, withRelated);
        }

        [HttpPost("episode")]
        public void CreateEpisodeImage(CreateEpisodeImageModel createEpisodeImageModel)
        {
            this.imageService.CreateEpisodeImage(createEpisodeImageModel);
        }

        [HttpPut("episode")]
        public void UpdateEpisodeImage(UpdateEpisodeImageModel updateEpisodeImageModel)
        {
            this.imageService.UpdateEpisodeImage(updateEpisodeImageModel);
        }

        [HttpDelete("{id}")]
        public void DeleteImage(int id)
        {
            this.imageService.DeleteImage(id);
        }

    }
}
