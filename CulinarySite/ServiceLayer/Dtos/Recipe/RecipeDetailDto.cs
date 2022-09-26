
using ServiceLayer.Dtos.Ingredient;
using ServiceLayer.Dtos.OrganicMatter;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.Tag;
using System;
using System.Collections.Generic;
using ServiceLayer.Dtos.Image.RecipeImage;

namespace ServiceLayer.Dtos.Recipe
{
    public class RecipeDetailDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public int DishId { get; set; }
        public int AuthorId { get; set; }
        public int? BookId { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();        
        public List<OrganicMatterDto> OrganicMatters { get; set; } = new List<OrganicMatterDto>();
        public List<CookingStageDto> CookingStages { get; set; } = new List<CookingStageDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public RecipeImageDto Image { get; set; }
    }
}
