using ServiceLayer;
using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetBookListWithInclude()
        {
            return this.bookService.GetBookListWithInclude();
        }

        [HttpGet("{id}")]
        public Book GetBookWithInclude(int id)
        {
            return this.bookService.GetBookWithInclude(id);
        }

        [HttpPost]
        public void CreateBook(Book book)
        {
            this.bookService.CreateBook(book);
        }

        [HttpPut]
        public void UpdateBook(Book book)
        {
            this.bookService.UpdateBook(book);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            this.bookService.DeleteBook(id);
        }
    }
}

