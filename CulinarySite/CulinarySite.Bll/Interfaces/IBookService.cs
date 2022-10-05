using CulinarySite.Common.Dtos.Book;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
{
    public interface IBookService
    {
        void CreateBook(CreateBookDto createBookDto);
        void UpdateBook(UpdateBookDto updateBookDto);
        void DeleteBook(int id);
        IEnumerable<BookDetailListDto> GetBookDetailList(bool withRelated);
        IEnumerable<BookDto> GetBookList();
        BookDetailDto GetBook(int id, bool withRelated);        
        IEnumerable<BookDetailListDto> GetSortedBooksByName(bool withRelated);
        IEnumerable<BookDetailListDto> GetSortedBooksByYear(bool withRelated);
    }
}
