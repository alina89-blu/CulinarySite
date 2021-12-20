using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface IImageService
    {
        void CreateImage(Image Image);
        void UpdateImage(Image Image);
        void DeleteImage(int id);
        IEnumerable<Image> GetImageList();
        Image GetImage(int id);
    }
}
