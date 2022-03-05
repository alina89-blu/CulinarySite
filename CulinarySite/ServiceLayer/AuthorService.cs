using System.Collections.Generic;
using Repositories;
using Database;
using ServiceLayer.ViewModels.Author;
using ServiceLayer.ViewModels.Recipe;
using System.Linq;
using ServiceLayer.ViewModels.Book;

namespace ServiceLayer
{
    public class AuthorService : IAuthorService
    {
        private readonly IReadOnlyGenericRepository<Author> authorReadOnlyRepository;
        private readonly IWriteGenericRepository<Book> bookWriteRepository;
        private readonly IWriteGenericRepository<Author> authorWriteRepository;
        public AuthorService(
            IReadOnlyGenericRepository<Author> authorReadOnlyRepository,
            IWriteGenericRepository<Book> bookWriteRepository,
            IWriteGenericRepository<Author> authorWriteRepository)
        {
            this.authorReadOnlyRepository = authorReadOnlyRepository;
            this.bookWriteRepository = bookWriteRepository;
            this.authorWriteRepository = authorWriteRepository;
        }

        public void CreateAuthor(CreateAuthorModel createAuthorModel)
        {
            var books = createAuthorModel
                .Books
                .Select(x => this.bookWriteRepository.GetItem(x.BookId))
                .ToList();

            var author = new Author()
            {
                Name = createAuthorModel.Name,
                Books = books
            };
            this.authorWriteRepository.Create(author);
            this.authorWriteRepository.Save();
        }

        public void UpdateAuthor(UpdateAuthorModel updateAuthorModel)
        {
            var books = updateAuthorModel
                 .Books
                 .Select(x => this.bookWriteRepository.GetItem(x.BookId))
                 .ToList();

            var author = new Author
            {
                Id = updateAuthorModel.AuthorId,
                Name = updateAuthorModel.Name,
                Books = books
            };
            this.authorWriteRepository.Update(author);
            this.authorWriteRepository.Save();
        }

        public void DeleteAuthor(int id)
        {
            this.authorWriteRepository.Delete(id);
            this.authorWriteRepository.Save();
        }

        public AuthorDetailModel GetAuthor(int id, bool withRelated)
        {
            var author = new Author();
            AuthorDetailModel authorDetailModel = new AuthorDetailModel();
            if (withRelated)
            {
                author = authorReadOnlyRepository.GetItemWithInclude(
                       x => x.Id == id,
                       x => x.Books,
                       x => x.Recipes);

                List<BookModel> bookModels = new List<BookModel>();
                foreach (var book in author.Books)
                {
                    bookModels.Add(new BookModel
                    {
                        BookId = book.Id,
                        Name = book.Name
                    });
                }
                authorDetailModel = new AuthorDetailModel
                {
                    AuthorId = author.Id,
                    Name = author.Name,
                    Books = bookModels
                };
                return authorDetailModel;
            }
            author = authorReadOnlyRepository.GetItem(id);
            authorDetailModel = new AuthorDetailModel
            {
                AuthorId = author.Id,
                Name = author.Name
            };
            return authorDetailModel;
        }

        public IEnumerable<AuthorDetailListModel> GetAuthorDetailList(bool withRelated)
        {
            IEnumerable<Author> authors;
            List<AuthorDetailListModel> authorListModels = new List<AuthorDetailListModel>();         

            if (withRelated)
            {
                authors = this.authorReadOnlyRepository.GetItemListWithInclude(
                    x => x.Books,
                    x => x.Recipes);

                foreach (var author in authors)
                {
                    var recipeModels = new List<RecipeModel>();
                    foreach (var recipe in author.Recipes)
                    {                        
                        recipeModels.Add(new RecipeModel {  Name = recipe.Name});
                    }

                    var bookModels = new List<BookModel>();
                    foreach (var book in author.Books)
                    {                        
                        bookModels.Add(new BookModel { BookId = book.Id, Name = book.Name });
                    }

                    authorListModels.Add(new AuthorDetailListModel
                    {
                        AuthorId = author.Id,
                        Name = author.Name,
                        RecipeModels = recipeModels,
                        Books = bookModels
                    });

                    /*foreach (var recipe in author.Recipes)
                    {
                        //recipeModels.Add(new RecipeModel { Id = recipe.Id, Name = recipe.Name, AuthorId = author.Id });                       
                        authorListModels.Add(new AuthorListModel
                        {
                            Id = author.Id,
                            Name = author.Name,
                            RecipeModels = new List<RecipeModel> { new RecipeModel { AuthorId = author.Id, Name = recipe.Name, Id = recipe.Id } }
                        });
                    }*/
                }
                return authorListModels;
            }
            authors = authorReadOnlyRepository.GetItemList();
            foreach (var author in authors)
            {
                authorListModels.Add(new AuthorDetailListModel
                {
                    AuthorId = author.Id,
                    Name = author.Name
                });
            }
            return authorListModels;
        }

        public IEnumerable<AuthorModel> GetAuthorList()
        {
            IEnumerable<Author> authors = this.authorReadOnlyRepository.GetItemList();
            List<AuthorModel> authorModels = new List<AuthorModel>();

            foreach (var author in authors)
            {
                authorModels.Add(new AuthorModel
                {
                    AuthorId = author.Id,
                    Name = author.Name
                });
            }
            return authorModels;
        }

    }
}
