using System;
using System.Collections.Generic;

namespace Database
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationYear { get; set; }
        public string Description { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Image> Images { get; set; } = new List<Image>();
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
