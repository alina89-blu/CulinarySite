using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Author : BaseEntity
    {       
        public string Name { get; set; }       
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
