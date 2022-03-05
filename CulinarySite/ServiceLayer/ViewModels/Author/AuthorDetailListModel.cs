
using ServiceLayer.ViewModels.Book;
using ServiceLayer.ViewModels.Recipe;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Author
{
    public class AuthorDetailListModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<RecipeModel> RecipeModels { get; set; } = new List<RecipeModel>();
        public List<BookModel> Books { get; set; } = new List<BookModel>();

    }
}
