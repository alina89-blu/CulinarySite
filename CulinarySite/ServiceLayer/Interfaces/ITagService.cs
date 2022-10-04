using System.Collections.Generic;
using ServiceLayer.Dtos.Tag;

namespace ServiceLayer
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
