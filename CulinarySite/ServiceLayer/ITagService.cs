using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ITagService
    {
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int id);
        IEnumerable<Tag> GetTagListWithInclude();
        Tag GetTagWithInclude(int id);
    }
}
