
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int CreationYear { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Image> Images { get; set; } = new List<Image>();
        public int AuthorId { get; set; }       
        public Author Author { get; set; }
    }
}
