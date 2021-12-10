using Database;
using System;
using System.Linq.Expressions;

namespace ServiceLayer
{
  public  interface IAuthorService
    {
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);      
        Author GetAuthorWithInclude(int id);        
    }
}
