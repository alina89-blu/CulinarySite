
namespace ServiceLayer.Dtos.Book
{
    public class BookDetailListDto
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
    }
}
