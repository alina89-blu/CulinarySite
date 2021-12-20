using System.Collections.Generic;
using Database;
using Repositories;

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

        public void CreateCulinaryChannel(CulinaryChannel culinaryChannel)
        {
            this.culinaryChannelWriteRepository.Create(culinaryChannel);
            this.culinaryChannelWriteRepository.Save();
        }

        public void UpdateCulinaryChannel(CulinaryChannel culinaryChannel)
        {
            this.culinaryChannelWriteRepository.Update(culinaryChannel);
            this.culinaryChannelWriteRepository.Save();
        }

        public void DeleteCulinaryChannel(int id)
        {
            this.culinaryChannelWriteRepository.Delete(id);
            this.culinaryChannelWriteRepository.Save();
        }

        public IEnumerable<CulinaryChannel> GetCulinaryChannelListWithInclude()
        {
            return this.culinaryChannelReadOnlyRepository.GetItemListWithInclude(x => x.Episodes);
        }

        public CulinaryChannel GetCulinaryChannelWithInclude(int id)
        {
            return this.culinaryChannelReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Episodes);
        }
    }
}
