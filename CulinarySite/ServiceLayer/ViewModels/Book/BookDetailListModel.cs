using System;

namespace ServiceLayer.ViewModels.Book
{
    public class BookDetailListModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime CreationYear { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
    }
}
