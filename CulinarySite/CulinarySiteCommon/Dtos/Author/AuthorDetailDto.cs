using CulinarySite.Common.Dtos.Book;
using System.Collections.Generic;

namespace CulinarySite.Common.Dtos.Author
{
    public class AuthorDetailDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
