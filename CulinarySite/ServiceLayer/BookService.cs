using System.Collections.Generic;
using Database;
using Repositories;
using ServiceLayer.ViewModels.Book;

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

        public void CreateBook(CreateBookModel createBookModel)
        {
            var book = new Book
            {
                Name = createBookModel.Name,
                CreationYear = createBookModel.CreationYear,
                Description = createBookModel.Description,
                AuthorId = createBookModel.AuthorId

                // Author = new Author { Name = createBookModel.AuthorName }
            };
            this.bookWriteRepository.Create(book);
            this.bookWriteRepository.Save();
        }

        public void UpdateBook(UpdateBookModel updateBookModel)
        {
            var book = new Book
            {
                Id = updateBookModel.BookId,
                Name = updateBookModel.Name,
                CreationYear = updateBookModel.CreationYear,
                Description = updateBookModel.Description,
                AuthorId = updateBookModel.AuthorId
            };
            this.bookWriteRepository.Update(book);
            this.bookWriteRepository.Save();
        }

        public void DeleteBook(int id)
        {
            this.bookWriteRepository.Delete(id);
            this.bookWriteRepository.Save();
        }

        public IEnumerable<BookDetailListModel> GetBookDetailList(bool withRelated)
        {
            IEnumerable<Book> books;
            List<BookDetailListModel> bookDetailListModels = new List<BookDetailListModel>();
            if (withRelated)
            {
                books = this.bookReadOnlyRepository.GetItemListWithInclude(
                x => x.Author);
                foreach (var book in books)
                {
                    bookDetailListModels.Add(new BookDetailListModel
                    {
                        BookId = book.Id,
                        Name = book.Name,
                        CreationYear = book.CreationYear,
                        Description = book.Description,
                        AuthorName = book.Author?.Name
                    });
                }
                return bookDetailListModels;
            }

            books = this.bookReadOnlyRepository.GetItemList();
            foreach (var book in books)
            {
                bookDetailListModels.Add(new BookDetailListModel
                {
                    BookId = book.Id,
                    Name = book.Name,
                    CreationYear = book.CreationYear,
                    Description = book.Description
                });
            }
            return bookDetailListModels;
        }

        public BookDetailModel GetBook(int id, bool withRelated)
        {
            Book book;
            BookDetailModel bookDetailModel = new BookDetailModel();

            if (withRelated)
            {
                book = this.bookReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Author);
                bookDetailModel = new BookDetailModel
                {
                    BookId = book.Id,
                    Name = book.Name,
                    CreationYear = book.CreationYear,
                    Description = book.Description,
                    AuthorId = book.AuthorId  //

                };
                return bookDetailModel;
            }
            book = this.bookReadOnlyRepository.GetItem(id);
            bookDetailModel = new BookDetailModel
            {
                BookId = book.Id,
                Name = book.Name,
                CreationYear = book.CreationYear,
                Description = book.Description,
            };
            return bookDetailModel;
        }

        public IEnumerable<BookModel> GetBookList()
        {
            IEnumerable<Book> books = this.bookReadOnlyRepository.GetItemList();
            List<BookModel> bookModels = new List<BookModel>();

            foreach (var book in books)
            {
                bookModels.Add(new BookModel
                {
                    BookId = book.Id,
                    Name = book.Name
                });
            }
            return bookModels;
        }
    }
}
