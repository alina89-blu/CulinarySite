using System.Collections.Generic;
using ServiceLayer.ViewModels.Tag;

namespace ServiceLayer
{
    public interface ITagService
    {
        void CreateTag(CreateTagModel createTagModel);
        void UpdateTag(UpdateTagModel updateTagModel);
        void DeleteTag(int id);
        IEnumerable<TagListModel> GetTagList(bool withRelated);
        TagDetailModel GetTag(int id, bool withRelated);
    }
}
