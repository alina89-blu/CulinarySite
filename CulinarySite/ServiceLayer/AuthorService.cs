using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Database;

namespace ServiceLayer
{
    public class AuthorService : IAuthorService
    {
        private readonly IReadOnlyGenericRepository<Author> authorReadOnlyRepository;
        private readonly IWriteGenericRepository<Author> authorWriteRepository;
        public AuthorService(IReadOnlyGenericRepository<Author> authorReadOnlyRepository, IWriteGenericRepository<Author> authorWriteRepository)
        {
            this.authorReadOnlyRepository = authorReadOnlyRepository;
            this.authorWriteRepository = authorWriteRepository;
        }
        public void CreateAuthor(Author author)
        {
            this.authorWriteRepository.Create(author);
            this.authorWriteRepository.Save();
        }
        public void UpdateAuthor(Author author)
        {
            this.authorWriteRepository.Update(author);
            this.authorWriteRepository.Save();
        }
        public void DeleteAuthor(int id)
        {
            this.authorWriteRepository.Delete(id);
            this.authorWriteRepository.Save();
        }
        public Author GetAuthorWithInclude(int id)
        {
            return authorReadOnlyRepository.GetItemWithInclude(x => x.Id == id, x => x.Books);
        }
    }
}
