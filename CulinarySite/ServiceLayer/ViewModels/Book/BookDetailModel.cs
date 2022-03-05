using System;

namespace ServiceLayer.ViewModels.Book
{
    public class BookDetailModel
    {
        public int BookId { get; set; }
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime CreationYear { get; set; }
        public string Description { get; set; }

    }
}
