using System;
using System.Collections.Generic;

namespace Database
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
  
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public List<RecipeOrganicMatter> RecipeOrganicMatters { get; set; } = new List<RecipeOrganicMatter>();              
        public List<CookingStage> CookingStages { get; set; } = new List<CookingStage>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }

       
    }
}
