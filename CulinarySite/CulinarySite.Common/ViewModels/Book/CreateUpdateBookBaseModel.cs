
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Book
{
    public class CreateUpdateBookBaseModel
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public int CreationYear { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
