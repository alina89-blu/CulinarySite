using ServiceLayer;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Book;

namespace CulinarySite.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<BookDetailListModel> GetBookDetailList(bool withRelated)
        {
            return this.bookService.GetBookDetailList(withRelated);
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBookList()
        {
            return this.bookService.GetBookList();
        }

        [HttpGet("{id}/{withRelated}")]
        public BookDetailModel GetBook(int id, bool withRelated)
        {
            return this.bookService.GetBook(id, withRelated);
        }

        [HttpPost]
        public void CreateBook(CreateBookModel createBookModel)
        {
            this.bookService.CreateBook(createBookModel);
        }

        [HttpPut]
        public void UpdateBook(UpdateBookModel updateBookModel)
        {
            this.bookService.UpdateBook(updateBookModel);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            this.bookService.DeleteBook(id);
        }
    }
}

