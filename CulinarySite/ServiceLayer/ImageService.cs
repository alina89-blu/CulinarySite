using System.Collections.Generic;
using Repositories;
using Database;

namespace ServiceLayer
{
    public class ImageService : IImageService
    {
        private readonly IReadOnlyGenericRepository<Image> imageReadOnlyRepository;
        private readonly IWriteGenericRepository<Image> imageWriteRepository;
        public ImageService(
            IReadOnlyGenericRepository<Image> imageReadOnlyRepository,
            IWriteGenericRepository<Image> imageWriteRepository)
        {
            this.imageReadOnlyRepository = imageReadOnlyRepository;
            this.imageWriteRepository = imageWriteRepository;
        }

        public void CreateImage(Image image)
        {
            this.imageWriteRepository.Create(image);
            this.imageWriteRepository.Save();
        }

        public void UpdateImage(Image image)
        {
            this.imageWriteRepository.Update(image);
            this.imageWriteRepository.Save();
        }

        public void DeleteImage(int id)
        {
            this.imageWriteRepository.Delete(id);
            this.imageWriteRepository.Save();
        }

        public IEnumerable<Image> GetImageList()
        {
            return this.imageReadOnlyRepository.GetItemList();
        }

        public Image GetImage(int id)
        {
            return this.imageReadOnlyRepository.GetItem(id);
        }
    }
}
