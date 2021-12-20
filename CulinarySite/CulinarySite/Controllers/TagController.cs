using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public IEnumerable<Tag> GetTagListWithInclude()
        {
            return this.tagService.GetTagListWithInclude();
        }

        [HttpGet("{id}")]
        public Tag GetTagWithInclude(int id)
        {
            return this.tagService.GetTagWithInclude(id);
        }

        [HttpPost]
        public void CreateTag(Tag tag)
        {
            this.tagService.CreateTag(tag);
        }

        [HttpPut]
        public void UpdateTag(Tag tag)
        {
            this.tagService.UpdateTag(tag);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id)
        {
            this.tagService.DeleteTag(id);
        }
    }
}
