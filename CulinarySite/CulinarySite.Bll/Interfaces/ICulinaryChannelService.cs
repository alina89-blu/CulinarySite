using CulinarySite.Common.Dtos.CulinaryChannel;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
