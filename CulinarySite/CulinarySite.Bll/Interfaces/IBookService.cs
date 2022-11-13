using CulinarySite.Common.Dtos.Book;
using CulinarySite.Common.Pagination;
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
        PagedList<BookDetailListDto> GetPaginatedBooks(PagingParameters pagingParameters);

    }
}
