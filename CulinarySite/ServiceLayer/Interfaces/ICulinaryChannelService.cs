using System.Collections.Generic;
using ServiceLayer.Dtos.CulinaryChannel;

namespace ServiceLayer
{
    public interface ICulinaryChannelService
    {
        void CreateCulinaryChannel(CreateCulinaryChannelDto createCulinaryChannelDto);
        void UpdateCulinaryChannel(UpdateCulinaryChannelDto updateCulinaryChannelDto);
        void DeleteCulinaryChannel(int id);
        IEnumerable<CulinaryChannelListDto> GetCulinaryChannelList(bool withRelated);
        CulinaryChannelDetailDto GetCulinaryChannel(int id, bool withRelated);
    }
}
