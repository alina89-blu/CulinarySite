using System.Collections.Generic;
using Database;

namespace ServiceLayer
{
    public interface IBookService
    {
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        IEnumerable<Book> GetBookListWithInclude();
        Book GetBookWithInclude(int id);
    }
}
