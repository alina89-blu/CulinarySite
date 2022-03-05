using System.Collections.Generic;
using ServiceLayer.ViewModels.Book;

namespace ServiceLayer
{
    public interface IBookService
    {
        void CreateBook(CreateBookModel createBookModel);
        void UpdateBook(UpdateBookModel updateBookModel);
        void DeleteBook(int id);
        IEnumerable<BookDetailListModel> GetBookDetailList(bool withRelated);
        BookDetailModel GetBook(int id, bool withRelated);
        IEnumerable<BookModel> GetBookList();
    }
}
