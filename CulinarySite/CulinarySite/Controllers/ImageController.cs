using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;


namespace CulinarySite.Controllers
{
    public class ImageController : BaseController
    {
        private readonly IImageService imageService;
        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet]
        public IEnumerable<Image> GetImageList()
        {
            return this.imageService.GetImageList();
        }

        [HttpGet("{id}")]
        public Image GetImage(int id)
        {
            return this.imageService.GetImage(id);
        }

        [HttpPost]
        public void CreateImage(Image image)
        {
            this.imageService.CreateImage(image);
        }

        [HttpPut]
        public void UpdateImage(Image image)
        {
            this.imageService.UpdateImage(image);
        }

        [HttpDelete("{id}")]
        public void DeleteImage(int id)
        {
            this.imageService.DeleteImage(id);
        }
    }
}
