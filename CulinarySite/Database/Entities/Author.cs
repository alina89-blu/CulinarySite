using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }       
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
