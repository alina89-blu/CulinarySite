using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
