using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface ICulinaryChannelService
    {
        void CreateCulinaryChannel(CulinaryChannel culinaryChannel);
        void UpdateCulinaryChannel(CulinaryChannel culinaryChannel);
        void DeleteCulinaryChannel(int id);
        IEnumerable<CulinaryChannel> GetCulinaryChannelListWithInclude();
        CulinaryChannel GetCulinaryChannelWithInclude(int id);
    }
}
