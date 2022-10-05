
using CulinarySite.Common.ViewModels.Book;
using System.Collections.Generic;

namespace CulinarySite.Common.ViewModels.Author
{
    public class AuthorDetailModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
