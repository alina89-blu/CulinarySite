using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
