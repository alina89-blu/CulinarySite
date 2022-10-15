
namespace CulinarySite.Common.ViewModels.Book
{
    public class BookDetailModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

    }
}

