using System;
using System.Collections.Generic;
using ServiceLayer.Dtos.Ingredient;
using ServiceLayer.Dtos.OrganicMatter;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.Tag;

namespace ServiceLayer.Dtos.Recipe
{
    public class RecipeListDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public string DishCategory { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
        public List<OrganicMatterDto> OrganicMatters { get; set; } = new List<OrganicMatterDto>();
        public List<CookingStageDto> CookingStages { get; set; } = new List<CookingStageDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
