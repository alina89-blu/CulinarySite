using System.Collections.Generic;
using Database;
using Repositories;

namespace ServiceLayer
{
    public class BookService : IBookService
    {
        private readonly IReadOnlyGenericRepository<Book> bookReadOnlyRepository;
        private readonly IWriteGenericRepository<Book> bookWriteRepository;
        public BookService(
            IReadOnlyGenericRepository<Book> bookReadOnlyRepository,
            IWriteGenericRepository<Book> bookWriteRepository)
        {
            this.bookReadOnlyRepository = bookReadOnlyRepository;
            this.bookWriteRepository = bookWriteRepository;
        }

        public void CreateBook(Book book)
        {
            this.bookWriteRepository.Create(book);
            this.bookWriteRepository.Save();
        }

        public void UpdateBook(Book book)
        {
            this.bookWriteRepository.Update(book);
            this.bookWriteRepository.Save();
        }

        public void DeleteBook(int id)
        {
            this.bookWriteRepository.Delete(id);
            this.bookWriteRepository.Save();
        }

        public IEnumerable<Book> GetBookListWithInclude()
        {
            return this.bookReadOnlyRepository.GetItemListWithInclude(
                x => x.Recipes,
                x => x.Images,
                x => x.Author);
        }

        public Book GetBookWithInclude(int id)
        {
            return this.bookReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipes,
                x => x.Images,
                x => x.Author);
        }
    }
}
