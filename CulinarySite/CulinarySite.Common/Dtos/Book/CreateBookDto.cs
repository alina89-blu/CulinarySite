﻿
namespace CulinarySite.Common.Dtos.Book
{
    public class CreateBookDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
