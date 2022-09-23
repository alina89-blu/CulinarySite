using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }       
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
