using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Image.DishImage;
using CulinarySite.Common.Dtos.Image.EpisodeImage;
using CulinarySite.Common.Dtos.Image.RecipeImage;
using CulinarySite.Common.ViewModels.Image.DishImage;
using CulinarySite.Common.ViewModels.Image.EpisodeImage;
using CulinarySite.Common.ViewModels.Image.RecipeImage;
using Microsoft.AspNetCore.Mvc;


namespace CulinarySite.Api.Controllers
{
    public class ImageController : ApiController
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public ImageController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}/dish")]
        public IEnumerable<DishImageListModel> GetDishImageList(bool withRelated)
        {
            IEnumerable<DishImageListDto> dishImageListDtos = _imageService.GetDishImageList(withRelated);
            var dishImageListModels = new List<DishImageListModel>();

            foreach (var dishImageListDto in dishImageListDtos)
            {
                dishImageListModels.Add(_mapper.Map<DishImageListModel>(dishImageListDto));
            }

            return dishImageListModels;
        }

        [HttpGet("{id}/{withRelated}/dish")]
        public DishImageDetailModel GetDishImage(int id, bool withRelated)
        {
            DishImageDetailDto dishImageDetailDto = _imageService.GetDishImage(id, withRelated);
            DishImageDetailModel dishImageDetailModel = _mapper.Map<DishImageDetailModel>(dishImageDetailDto);

            return dishImageDetailModel;
        }

        [HttpPost("dish")]
        public void CreateDishImage(CreateDishImageModel createDishImageModel)
        {
            CreateDishImageDto createDishImageDto = _mapper.Map<CreateDishImageDto>(createDishImageModel);
            _imageService.CreateDishImage(createDishImageDto);
        }

        [HttpPut("dish")]
        public void UpdateDishImage(UpdateDishImageModel updateDishImageModel)
        {
            UpdateDishImageDto updateDishImageDto = _mapper.Map<UpdateDishImageDto>(updateDishImageModel);
            _imageService.UpdateDishImage(updateDishImageDto);
        }

        [HttpGet("{withRelated}/episode")]
        public IEnumerable<EpisodeImageListModel> GetEpisodeImageList(bool withRelated)
        {
            IEnumerable<EpisodeImageListDto> episodeImageListDtos = _imageService.GetEpisodeImageList(withRelated);
            var episodeImageListModels = new List<EpisodeImageListModel>();

            foreach (var episodeImageListDto in episodeImageListDtos)
            {
                episodeImageListModels.Add(_mapper.Map<EpisodeImageListModel>(episodeImageListDto));
            }

            return episodeImageListModels;
        }

        [HttpGet("{id}/{withRelated}/episode")]
        public EpisodeImageDetailModel GetEpisodeImage(int id, bool withRelated)
        {
            EpisodeImageDetailDto episodeImageDetailDto = _imageService.GetEpisodeImage(id, withRelated);
            EpisodeImageDetailModel episodeImageDetailModel = _mapper.Map<EpisodeImageDetailModel>(episodeImageDetailDto);

            return episodeImageDetailModel;
        }

        [HttpPost("episode")]
        public void CreateEpisodeImage(CreateEpisodeImageModel createEpisodeImageModel)
        {
            CreateEpisodeImageDto createEpisodeImageDto = _mapper.Map<CreateEpisodeImageDto>(createEpisodeImageModel);
            _imageService.CreateEpisodeImage(createEpisodeImageDto);
        }

        [HttpPut("episode")]
        public void UpdateEpisodeImage(UpdateEpisodeImageModel updateEpisodeImageModel)
        {
            UpdateEpisodeImageDto updateEpisodeImageDto = _mapper.Map<UpdateEpisodeImageDto>(updateEpisodeImageModel);
            _imageService.UpdateEpisodeImage(updateEpisodeImageDto);
        }

        [HttpDelete("{id}")]
        public void DeleteImage(int id)
        {
            _imageService.DeleteImage(id);
        }
        
        [HttpGet("{withRelated}/recipe")]
        public IEnumerable<RecipeImageListModel> GetRecipeImageList(bool withRelated)
        {
            IEnumerable<RecipeImageListDto> recipeImageListDtos = _imageService.GetRecipeImageList(withRelated);
            var recipeImageListModels = new List<RecipeImageListModel>();

            foreach (var recipeImageListDto in recipeImageListDtos)
            {
                recipeImageListModels.Add(_mapper.Map<RecipeImageListModel>(recipeImageListDto));
            }

            return recipeImageListModels;
        }

        [HttpGet("{id}/{withRelated}/recipe")]
        public RecipeImageDetailModel GetRecipeImage(int id, bool withRelated)
        {
            RecipeImageDetailDto recipeImageDetailDto = _imageService.GetRecipeImage(id, withRelated);
            RecipeImageDetailModel recipeImageDetailModel = _mapper.Map<RecipeImageDetailModel>(recipeImageDetailDto);

            return recipeImageDetailModel;
        }

        [HttpPost("recipe")]
        public void CreateRecipeImage(CreateRecipeImageModel createRecipeImageModel)
        {
            CreateRecipeImageDto createRecipeImageDto = _mapper.Map<CreateRecipeImageDto>(createRecipeImageModel);
            _imageService.CreateRecipeImage(createRecipeImageDto);
        }

        [HttpPut("recipe")]
        public void UpdateRecipeImage(UpdateRecipeImageModel updateRecipeImageModel)
        {
            UpdateRecipeImageDto updateRecipeImageDto = _mapper.Map<UpdateRecipeImageDto>(updateRecipeImageModel);
            _imageService.UpdateRecipeImage(updateRecipeImageDto);
        }

       

    }
}
