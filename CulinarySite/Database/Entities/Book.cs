using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Book : BaseEntity
    {       
        public string Name { get; set; }
        public int CreationYear { get; set; }     
        public string Description { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Image> Images { get; set; } = new List<Image>();
        public int AuthorId { get; set; }       
        public Author Author { get; set; }
    }
}
