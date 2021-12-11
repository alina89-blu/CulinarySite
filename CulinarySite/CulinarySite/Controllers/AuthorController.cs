using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulinarySite.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<Author> GetAuthorListWithInclude()
        {
            return this.authorService.GetAuthorListWithInclude();
        }

        [HttpGet("{id}")]
        public Author GetAuthorWithInclude(int id)
        {
            return this.authorService.GetAuthorWithInclude(id);
        }

        [HttpPost]
        public void CreateAuthor(Author author)
        {
            this.authorService.CreateAuthor(author);
        }

        [HttpPut]
        public void UpdateAuthor(Author author)
        {
            this.authorService.UpdateAuthor(author);
        }

        [HttpDelete("{id}")]
        public void DeleteAuthor(int id)
        {
            this.authorService.DeleteAuthor(id);
        }
    }
}


