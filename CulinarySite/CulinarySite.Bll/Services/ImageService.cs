using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Image.DishImage;
using CulinarySite.Common.Dtos.Image.EpisodeImage;
using CulinarySite.Common.Dtos.Image.RecipeImage;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
{
    public class ImageService : IImageService
    {
        private readonly IReadOnlyGenericRepository<Image> _imageReadOnlyRepository;
        private readonly IWriteGenericRepository<Image> _imageWriteRepository;
        private readonly IMapper _mapper;
        public ImageService(
            IReadOnlyGenericRepository<Image> imageReadOnlyRepository,
            IWriteGenericRepository<Image> imageWriteRepository,
            IMapper mapper)
        {
            _imageReadOnlyRepository = imageReadOnlyRepository;
            _imageWriteRepository = imageWriteRepository;
            _mapper = mapper;
        }

        public void CreateDishImage(CreateDishImageDto createDishImageDto)
        {
            Image image = _mapper.Map<Image>(createDishImageDto);

            _imageWriteRepository.Create(image);
            _imageWriteRepository.Save();
        }

        public void UpdateDishImage(UpdateDishImageDto updateDishImageDto)
        {
            Image image = _mapper.Map<Image>(updateDishImageDto);

            _imageWriteRepository.Update(image);
            _imageWriteRepository.Save();
        }

        public void DeleteImage(int id)
        {
            _imageWriteRepository.Delete(id);
            _imageWriteRepository.Save();
        }

        public IEnumerable<DishImageListDto> GetDishImageList(bool withRelated)
        {
            IEnumerable<Image> images;
            IEnumerable<DishImageListDto> dishImageListDtos;

            if (withRelated)
            {
                images = _imageReadOnlyRepository.GetItemListWithInclude(x => x.Dish);
                dishImageListDtos = images.Select(x => _mapper.Map<DishImageListDto>(x));
                
                return dishImageListDtos;
            }

            images = _imageReadOnlyRepository.GetItemList();
            dishImageListDtos = images.Select(x => _mapper.Map<DishImageListDto>(x));

            return dishImageListDtos;
        }

        public DishImageDetailDto GetDishImage(int id, bool withRelated)
        {
            var image = new Image();
            var dishImageDetailDto = new DishImageDetailDto();

            if (withRelated)
            {
                image = _imageReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Dish);

                dishImageDetailDto = _mapper.Map<DishImageDetailDto>(image);

                return dishImageDetailDto;
            }

            image = _imageReadOnlyRepository.GetItem(id);

            dishImageDetailDto = _mapper.Map<DishImageDetailDto>(image);

            return dishImageDetailDto;
        }

        public void CreateEpisodeImage(CreateEpisodeImageDto createEpisodeImageDto)
        {
            Image image = _mapper.Map<Image>(createEpisodeImageDto);

            _imageWriteRepository.Create(image);
            _imageWriteRepository.Save();
        }

        public void UpdateEpisodeImage(UpdateEpisodeImageDto updateEpisodeImageDto)
        {
            Image image = _mapper.Map<Image>(updateEpisodeImageDto);

            _imageWriteRepository.Update(image);
            _imageWriteRepository.Save();
        }

        public IEnumerable<EpisodeImageListDto> GetEpisodeImageList(bool withRelated)
        {
            IEnumerable<Image> images;
            IEnumerable<EpisodeImageListDto> episodeImageListDtos ;

            if (withRelated)
            {
                images = _imageReadOnlyRepository.GetItemListWithInclude(x => x.Episode);
                episodeImageListDtos = images.Select(x => _mapper.Map<EpisodeImageListDto>(x));                

                return episodeImageListDtos;
            }

            images = _imageReadOnlyRepository.GetItemList();
            episodeImageListDtos = images.Select(x => _mapper.Map<EpisodeImageListDto>(x));

            return episodeImageListDtos;
        }

        public EpisodeImageDetailDto GetEpisodeImage(int id, bool withRelated)
        {
            var image = new Image();
            var episodeImageDetailDto = new EpisodeImageDetailDto();

            if (withRelated)
            {
                image = _imageReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Episode);

                episodeImageDetailDto = _mapper.Map<EpisodeImageDetailDto>(image);

                return episodeImageDetailDto;
            }

            image = _imageReadOnlyRepository.GetItem(id);

            episodeImageDetailDto = _mapper.Map<EpisodeImageDetailDto>(image);

            return episodeImageDetailDto;
        }

        public void CreateRecipeImage(CreateRecipeImageDto createRecipeImageDto)
        {
            Image image = _mapper.Map<Image>(createRecipeImageDto);

            _imageWriteRepository.Create(image);
            _imageWriteRepository.Save();
        }

        public void UpdateRecipeImage(UpdateRecipeImageDto updateRecipeImageDto)
        {
            Image image = _mapper.Map<Image>(updateRecipeImageDto);

            _imageWriteRepository.Update(image);
            _imageWriteRepository.Save();
        }

        public IEnumerable<RecipeImageListDto> GetRecipeImageList(bool withRelated)
        {
            IEnumerable<Image> images;
            IEnumerable<RecipeImageListDto> recipeImageListDtos ;

            if (withRelated)
            {
                images = _imageReadOnlyRepository.GetItemListWithInclude(x => x.Recipe);
                recipeImageListDtos=images.Select(x=> _mapper.Map<RecipeImageListDto>(x));                

                return recipeImageListDtos;
            }

            images = _imageReadOnlyRepository.GetItemList();
            recipeImageListDtos = images.Select(x => _mapper.Map<RecipeImageListDto>(x));

            return recipeImageListDtos;
        }

        public RecipeImageDetailDto GetRecipeImage(int id, bool withRelated)
        {
            var image = new Image();
            var recipeImageDetailDto = new RecipeImageDetailDto();

            if (withRelated)
            {
                image = _imageReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Recipe);

                recipeImageDetailDto = _mapper.Map<RecipeImageDetailDto>(image);

                return recipeImageDetailDto;
            }

            image = _imageReadOnlyRepository.GetItem(id);

            recipeImageDetailDto = _mapper.Map<RecipeImageDetailDto>(image);

            return recipeImageDetailDto;
        }
    }
}
