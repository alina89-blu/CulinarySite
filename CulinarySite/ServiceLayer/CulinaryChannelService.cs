using System.Collections.Generic;
using Database;
using Repositories;
using ServiceLayer.ViewModels.CulinaryChannel;

namespace ServiceLayer
{
    public class CulinaryChannelService : ICulinaryChannelService
    {
        private readonly IReadOnlyGenericRepository<CulinaryChannel> culinaryChannelReadOnlyRepository;
        private readonly IWriteGenericRepository<CulinaryChannel> culinaryChannelWriteRepository;
        public CulinaryChannelService(
            IReadOnlyGenericRepository<CulinaryChannel> culinaryChannelReadOnlyRepository,
            IWriteGenericRepository<CulinaryChannel> culinaryChannelWriteRepository)
        {
            this.culinaryChannelReadOnlyRepository = culinaryChannelReadOnlyRepository;
            this.culinaryChannelWriteRepository = culinaryChannelWriteRepository;
        }

        public void CreateCulinaryChannel(CreateCulinaryChannelModel createCulinaryChannelModel)
        {
            var culinaryChannel = new CulinaryChannel
            {
                Name = createCulinaryChannelModel.Name,
                Content = createCulinaryChannelModel.Content
            };

            this.culinaryChannelWriteRepository.Create(culinaryChannel);
            this.culinaryChannelWriteRepository.Save();
        }

        public void UpdateCulinaryChannel(UpdateCulinaryChannelModel updateCulinaryChannelModel)
        {
            var culinaryChannel = new CulinaryChannel
            {
                Id = updateCulinaryChannelModel.CulinaryChannelId,
                Name = updateCulinaryChannelModel.Name,
                Content = updateCulinaryChannelModel.Content
            };
            this.culinaryChannelWriteRepository.Update(culinaryChannel);
            this.culinaryChannelWriteRepository.Save();
        }

        public void DeleteCulinaryChannel(int id)
        {
            this.culinaryChannelWriteRepository.Delete(id);
            this.culinaryChannelWriteRepository.Save();
        }

        public IEnumerable<CulinaryChannelListModel> GetCulinaryChannelList(bool withRelated)
        {
            IEnumerable<CulinaryChannel> culinaryChannels;
            List<CulinaryChannelListModel> culinaryChannelListModels = new List<CulinaryChannelListModel>();
            if (withRelated)
            {
                culinaryChannels = this.culinaryChannelReadOnlyRepository.GetItemListWithInclude();
                foreach (var culinaryChannel in culinaryChannels)
                {
                    culinaryChannelListModels.Add(new CulinaryChannelListModel
                    {
                        CulinaryChannelId = culinaryChannel.Id,
                        Name = culinaryChannel.Name,
                        Content = culinaryChannel.Content
                    });
                }
                return culinaryChannelListModels;
            }
            culinaryChannels = this.culinaryChannelReadOnlyRepository.GetItemList();
            foreach (var culinaryChannel in culinaryChannels)
            {
                culinaryChannelListModels.Add(new CulinaryChannelListModel
                {
                    CulinaryChannelId = culinaryChannel.Id,
                    Name = culinaryChannel.Name,
                    Content = culinaryChannel.Content
                });
            }
            return culinaryChannelListModels;
        }

        public CulinaryChannelDetailModel GetCulinaryChannel(int id, bool withRelated)
        {
            var culinaryChannel = new CulinaryChannel();
            CulinaryChannelDetailModel culinaryChannelDetailModel = new CulinaryChannelDetailModel();

            if (withRelated)
            {
                culinaryChannel = this.culinaryChannelReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id);
                culinaryChannelDetailModel = new CulinaryChannelDetailModel
                {
                    CulinaryChannelId = culinaryChannel.Id,
                    Name = culinaryChannel.Name,
                    Content = culinaryChannel.Content
                };
                return culinaryChannelDetailModel;
            }
            culinaryChannel = this.culinaryChannelReadOnlyRepository.GetItem(id);
            culinaryChannelDetailModel = new CulinaryChannelDetailModel
            {
                CulinaryChannelId = culinaryChannel.Id,
                Name = culinaryChannel.Name,
                Content = culinaryChannel.Content
            };
            return culinaryChannelDetailModel;
        }
    }
}
