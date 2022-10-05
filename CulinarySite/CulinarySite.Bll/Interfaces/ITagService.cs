using CulinarySite.Common.Dtos.Tag;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
{
    public interface ITagService
    {
        void CreateTag(CreateTagDto createTagDto);
        void UpdateTag(UpdateTagDto updateTagDto);
        void DeleteTag(int id);
        IEnumerable<TagListDto> GetTagList(bool withRelated);
        TagDetailDto GetTag(int id, bool withRelated);
    }
}
