using System.Collections.Generic;
using ServiceLayer.Dtos.Image.DishImage;
using ServiceLayer.Dtos.Image.EpisodeImage;

namespace ServiceLayer
{
    public interface IImageService
    {
        void CreateDishImage(CreateDishImageDto createDishImageDto);
        void UpdateDishImage(UpdateDishImageDto updateDishImageDto);
        IEnumerable<DishImageListDto> GetDishImageList(bool withRelated);
        DishImageDetailDto GetDishImage(int id, bool withRelated);

        void CreateEpisodeImage(CreateEpisodeImageDto createEpisodeImageDto);
        void UpdateEpisodeImage(UpdateEpisodeImageDto updateEpisodeImageDto);
        IEnumerable<EpisodeImageListDto> GetEpisodeImageList(bool withRelated);
        EpisodeImageDetailDto GetEpisodeImage(int id, bool withRelated);

        void DeleteImage(int id);
    }
}
