
namespace CulinarySite.Common.Dtos.Book
{
    public class UpdateBookDto
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public string Description { get; set; }
    }
}
