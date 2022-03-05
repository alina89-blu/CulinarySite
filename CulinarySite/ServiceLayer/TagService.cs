using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Tag;

namespace ServiceLayer
{
    public class TagService : ITagService
    {
        private readonly IReadOnlyGenericRepository<Tag> tagReadOnlyRepository;
        private readonly IWriteGenericRepository<Tag> tagWriteRepository;
        public TagService(
            IReadOnlyGenericRepository<Tag> tagReadOnlyRepository,
            IWriteGenericRepository<Tag> tagWriteRepository)
        {
            this.tagReadOnlyRepository = tagReadOnlyRepository;
            this.tagWriteRepository = tagWriteRepository;
        }

        public void CreateTag(CreateTagModel createTagModel)
        {
            var tag = new Tag
            {
                Text = createTagModel.Text
            };
            this.tagWriteRepository.Create(tag);
            this.tagWriteRepository.Save();
        }

        public void UpdateTag(UpdateTagModel updateTagModel)
        {
            var tag = new Tag
            {
                Id = updateTagModel.TagId,
                Text = updateTagModel.Text
            };
            this.tagWriteRepository.Update(tag);
            this.tagWriteRepository.Save();
        }

        public void DeleteTag(int id)
        {
            this.tagWriteRepository.Delete(id);
            this.tagWriteRepository.Save();
        }

        public IEnumerable<TagListModel> GetTagList(bool withRelated)
        {
            IEnumerable<Tag> tags;
            List<TagListModel> tagListModels = new List<TagListModel>();
            if (withRelated)
            {
                tags = this.tagReadOnlyRepository.GetItemListWithInclude(
                                x => x.Recipes,
                                x => x.Episodes);
                foreach (var tag in tags)
                {
                    tagListModels.Add(new TagListModel
                    {
                        TagId = tag.Id,
                        Text = tag.Text
                    });
                }
                return tagListModels;
            }
            tags = this.tagReadOnlyRepository.GetItemList();
            foreach (var tag in tags)
            {
                tagListModels.Add(new TagListModel
                {
                    TagId = tag.Id,
                    Text = tag.Text
                });
            }
            return tagListModels;
        }

        public TagDetailModel GetTag(int id, bool withRelated)
        {
            var tag = new Tag();
            var tagDetailModel = new TagDetailModel();
            if (withRelated)
            {
                tag = this.tagReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipes,
                x => x.Episodes);
                tagDetailModel = new TagDetailModel
                {
                    TagId = tag.Id,
                    Text = tag.Text
                };
                return tagDetailModel;
            }
            tag = this.tagReadOnlyRepository.GetItem(id);
            tagDetailModel = new TagDetailModel
            {
                TagId = tag.Id,
                Text = tag.Text
            };
            return tagDetailModel;
        }
    }
}
