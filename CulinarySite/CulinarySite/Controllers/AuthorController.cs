using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Author;

namespace CulinarySite.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<AuthorDetailListModel> GetAuthorList(bool withRelated)
        {
            return this.authorService.GetAuthorDetailList(withRelated);
        }

        [HttpGet]
        public IEnumerable<AuthorModel> GetAuthorList()
        {
            return this.authorService.GetAuthorList();
        }

        [HttpGet("{id}/{withRelated}")]
        public AuthorDetailModel GetAuthor(int id, bool withRelated)
        {
            return this.authorService.GetAuthor(id,withRelated);
        }

        [HttpPost]
        public void CreateAuthor(CreateAuthorModel createAuthorModel)
        {
            this.authorService.CreateAuthor(createAuthorModel);
        }

        [HttpPut]
        public void UpdateAuthor(UpdateAuthorModel updateAuthorModel)
        {
            this.authorService.UpdateAuthor(updateAuthorModel);
        }

        [HttpDelete("{id}")]
        public void DeleteAuthor(int id)
        {
            this.authorService.DeleteAuthor(id);
        }
    }
}


