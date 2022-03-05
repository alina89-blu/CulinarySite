using System.Collections.Generic;
using Repositories;
using Database;
using ServiceLayer.ViewModels.Image.DishImage;
using ServiceLayer.ViewModels.Image.EpisodeImage;

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

        public void CreateDishImage(CreateDishImageModel createDishImageModel)
        {
            var image = new Image
            {
                Name = createDishImageModel.Name,
                Url = createDishImageModel.Url,
                DishId = createDishImageModel.DishId
            };
            this.imageWriteRepository.Create(image);
            this.imageWriteRepository.Save();
        }

        public void UpdateDishImage(UpdateDishImageModel updateDishImageModel)
        {
            var image = new Image
            {
                Id = updateDishImageModel.DishImageId,
                Name = updateDishImageModel.Name,
                Url = updateDishImageModel.Url,
                DishId = updateDishImageModel.DishId
            };
            this.imageWriteRepository.Update(image);
            this.imageWriteRepository.Save();
        }

        public void DeleteImage(int id)
        {
            this.imageWriteRepository.Delete(id);
            this.imageWriteRepository.Save();
        }

        public IEnumerable<DishImageListModel> GetDishImageList(bool withRelated)
        {
            IEnumerable<Image> images;
            List<DishImageListModel> dishImageListModels = new List<DishImageListModel>();
            if (withRelated)
            {
                images = this.imageReadOnlyRepository.GetItemListWithInclude(x => x.Dish);
                foreach (var image in images)
                {
                    dishImageListModels.Add(new DishImageListModel
                    {
                        DishImageId = image.Id,
                        Name = image.Name,
                        Url = image.Url,
                        DishCategory = image.Dish.Category
                    });
                }
                return dishImageListModels;
            }
            images = this.imageReadOnlyRepository.GetItemList();
            foreach (var image in images)
            {
                dishImageListModels.Add(new DishImageListModel
                {
                    DishImageId = image.Id,
                    Name = image.Name,
                    Url = image.Url
                });
            }
            return dishImageListModels;
        }

        public DishImageDetailModel GetDishImage(int id, bool withRelated)
        {
            var image = new Image();
            DishImageDetailModel dishImageDetailModel = new DishImageDetailModel();

            if (withRelated)
            {
                image = this.imageReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Dish);
                dishImageDetailModel = new DishImageDetailModel
                {
                    DishImageId = image.Id,
                    Name = image.Name,
                    Url = image.Url,
                    DishId = image.DishId
                };
                return dishImageDetailModel;
            }
            image = this.imageReadOnlyRepository.GetItem(id);
            dishImageDetailModel = new DishImageDetailModel
            {
                DishImageId = image.Id,
                Name = image.Name,
                Url = image.Url,
            };
            return dishImageDetailModel;
        }

        public void CreateEpisodeImage(CreateEpisodeImageModel createEpisodeImageModel)
        {
            var image = new Image
            {
                Name = createEpisodeImageModel.Name,
                Url = createEpisodeImageModel.Url,
                EpisodeId = createEpisodeImageModel.EpisodeId
            };
            this.imageWriteRepository.Create(image);
            this.imageWriteRepository.Save();
        }

        public void UpdateEpisodeImage(UpdateEpisodeImageModel updateEpisodeImageModel)
        {
            var image = new Image
            {
                Id = updateEpisodeImageModel.EpisodeImageId,
                Name = updateEpisodeImageModel.Name,
                Url = updateEpisodeImageModel.Url,
                EpisodeId = updateEpisodeImageModel.EpisodeId
            };
            this.imageWriteRepository.Update(image);
            this.imageWriteRepository.Save();
        }
        
        public IEnumerable<EpisodeImageListModel> GetEpisodeImageList(bool withRelated)
        {
            IEnumerable<Image> images;
            List<EpisodeImageListModel> episodeImageListModels = new List<EpisodeImageListModel>();
            if (withRelated)
            {
                images = this.imageReadOnlyRepository.GetItemListWithInclude(x => x.Episode);
                foreach (var image in images)
                {
                    episodeImageListModels.Add(new EpisodeImageListModel
                    {
                        EpisodeImageId = image.Id,
                        Name = image.Name,
                        Url = image.Url,
                        EpisodeName = image.Episode.Name
                    });
                }
                return episodeImageListModels;
            }
            images = this.imageReadOnlyRepository.GetItemList();
            foreach (var image in images)
            {
                episodeImageListModels.Add(new EpisodeImageListModel
                {
                    EpisodeImageId = image.Id,
                    Name = image.Name,
                    Url = image.Url
                });
            }
            return episodeImageListModels;
        }

        public EpisodeImageDetailModel GetEpisodeImage(int id, bool withRelated)
        {
            var image = new Image();
            EpisodeImageDetailModel episodeImageDetailModel = new EpisodeImageDetailModel();

            if (withRelated)
            {
                image = this.imageReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Episode);
                episodeImageDetailModel = new EpisodeImageDetailModel
                {
                    EpisodeImageId = image.Id,
                    Name = image.Name,
                    Url = image.Url,
                    EpisodeId = image.EpisodeId
                };
                return episodeImageDetailModel;
            }
            image = this.imageReadOnlyRepository.GetItem(id);
            episodeImageDetailModel = new EpisodeImageDetailModel
            {
                EpisodeImageId = image.Id,
                Name = image.Name,
                Url = image.Url,
            };
            return episodeImageDetailModel;
        }
    }
}
