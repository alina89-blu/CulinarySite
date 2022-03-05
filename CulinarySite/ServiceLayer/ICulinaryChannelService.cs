using System.Collections.Generic;
using ServiceLayer.ViewModels.CulinaryChannel;

namespace ServiceLayer
{
    public interface ICulinaryChannelService
    {
        void CreateCulinaryChannel(CreateCulinaryChannelModel createCulinaryChannelModel);
        void UpdateCulinaryChannel(UpdateCulinaryChannelModel updateCulinaryChannelModel);
        void DeleteCulinaryChannel(int id);
        IEnumerable<CulinaryChannelListModel> GetCulinaryChannelList(bool withRelated);
        CulinaryChannelDetailModel GetCulinaryChannel(int id, bool withRelated);
    }
}
