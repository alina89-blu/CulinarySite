using System;
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Recipe
{
    public class CreateUpdateRecipeBaseModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public int ServingsNumber { get; set; }
        [Required]
        public DateTime CookingTime { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int DishId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}
