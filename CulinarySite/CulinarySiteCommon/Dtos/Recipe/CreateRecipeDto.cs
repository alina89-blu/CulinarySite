using ServiceLayer.Dtos.Tag;
using System.Collections.Generic;
using System;

namespace CulinarySite.Common.Dtos.Recipe
{
    public class CreateRecipeDto 
    {
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public int DishId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public List<CreateIngredientDto> Ingredients { get; set; } = new List<CreateIngredientDto>();
        public List<CreateOrganicMatterDto> OrganicMatters { get; set; } = new List<CreateOrganicMatterDto>();
        public List<CreateCookingStageDto> CookingStages { get; set; } = new List<CreateCookingStageDto>();
        public List<CreateTagDto> Tags { get; set; } = new List<CreateTagDto>();

    }
}
