using System.Collections.Generic;
using Repositories;
using Database;
using AutoMapper;
using ServiceLayer.Dtos.Image.DishImage;
using ServiceLayer.Dtos.Image.EpisodeImage;

namespace ServiceLayer
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
            var dishImageListDtos = new List<DishImageListDto>();

            if (withRelated)
            {
                images = _imageReadOnlyRepository.GetItemListWithInclude(x => x.Dish);

                foreach (var image in images)
                {
                    dishImageListDtos.Add(_mapper.Map<DishImageListDto>(image));
                }

                return dishImageListDtos;
            }

            images = _imageReadOnlyRepository.GetItemList();

            foreach (var image in images)
            {
                dishImageListDtos.Add(_mapper.Map<DishImageListDto>(image));
            }

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
            var episodeImageListDtos = new List<EpisodeImageListDto>();

            if (withRelated)
            {
                images = _imageReadOnlyRepository.GetItemListWithInclude(x => x.Episode);

                foreach (var image in images)
                {
                    episodeImageListDtos.Add(_mapper.Map<EpisodeImageListDto>(image));
                }

                return episodeImageListDtos;
            }

            images = _imageReadOnlyRepository.GetItemList();

            foreach (var image in images)
            {
                episodeImageListDtos.Add(_mapper.Map<EpisodeImageListDto>(image));
            }

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
    }
}
