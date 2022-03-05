

using ServiceLayer.ViewModels.Book;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Author
{
    public class CreateUpdateAuthorBaseModel
    {
        public string Name { get; set; }
        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
