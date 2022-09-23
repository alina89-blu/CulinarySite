using System.Collections.Generic;
using ServiceLayer.Dtos.Book;

namespace ServiceLayer
{
    public interface IBookService
    {
        void CreateBook(CreateBookDto createBookDto);
        void UpdateBook(UpdateBookDto updateBookDto);
        void DeleteBook(int id);
        IEnumerable<BookDetailListDto> GetBookDetailList(bool withRelated);
        BookDetailDto GetBook(int id, bool withRelated);
        IEnumerable<BookDto> GetBookList();
        IEnumerable<BookDetailListDto> GetSortedBooksByName(bool withRelated);
        IEnumerable<BookDetailListDto> GetSortedBooksByYear(bool withRelated);
    }
}
