
using System;

namespace ServiceLayer.ViewModels.Book
{
    public class CreateUpdateBookBaseModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public string Description { get; set; }
     
    }
}
