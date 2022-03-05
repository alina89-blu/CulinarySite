using System.Collections.Generic;
using ServiceLayer.ViewModels.Image.DishImage;
using ServiceLayer.ViewModels.Image.EpisodeImage;

namespace ServiceLayer
{
    public interface IImageService
    {
        void CreateDishImage(CreateDishImageModel createDishImageModel);
        void UpdateDishImage(UpdateDishImageModel updateDishImageModel);      
        IEnumerable<DishImageListModel> GetDishImageList(bool withRelated);
        DishImageDetailModel GetDishImage(int id, bool withRelated);

        void CreateEpisodeImage(CreateEpisodeImageModel createEpisodeImageModel);
        void UpdateEpisodeImage(UpdateEpisodeImageModel updateEpisodeImageModel);       
        IEnumerable<EpisodeImageListModel> GetEpisodeImageList(bool withRelated);
        EpisodeImageDetailModel GetEpisodeImage(int id, bool withRelated);

        void DeleteImage(int id);
    }
}
