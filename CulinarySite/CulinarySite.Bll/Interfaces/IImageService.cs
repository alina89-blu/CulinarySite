using CulinarySite.Common.Dtos.Image.DishImage;
using CulinarySite.Common.Dtos.Image.EpisodeImage;
using CulinarySite.Common.Dtos.Image.RecipeImage;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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

        void CreateRecipeImage(CreateRecipeImageDto createRecipeImageDto);
        void UpdateRecipeImage(UpdateRecipeImageDto updateRecipeImageDto);
        IEnumerable<RecipeImageListDto> GetRecipeImageList(bool withRelated);
        RecipeImageDetailDto GetRecipeImage(int id, bool withRelated);

        void DeleteImage(int id);
    }
}
