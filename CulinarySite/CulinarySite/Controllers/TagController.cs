using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Tag;

namespace CulinarySite.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<TagListModel> GetTagList(bool withRelated)
        {
            return this.tagService.GetTagList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public TagDetailModel GetTagWithInclude(int id, bool withRelated)
        {
            return this.tagService.GetTag(id, withRelated);
        }

        [HttpPost]
        public void CreateTag(CreateTagModel createTagModel)
        {
            this.tagService.CreateTag(createTagModel);
        }

        [HttpPut]
        public void UpdateTag(UpdateTagModel updateTagModel)
        {
            this.tagService.UpdateTag(updateTagModel);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id)
        {
            this.tagService.DeleteTag(id);
        }
    }
}
