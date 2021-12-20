using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IAuthorService
    {
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        Author GetAuthorWithInclude(int id);
        IEnumerable<Author> GetAuthorListWithInclude();
    }
}
