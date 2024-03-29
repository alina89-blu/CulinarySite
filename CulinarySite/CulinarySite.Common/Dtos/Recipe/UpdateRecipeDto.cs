﻿using CulinarySite.Common.Dtos.CookingStage;
using CulinarySite.Common.Dtos.Ingredient;
using CulinarySite.Common.Dtos.OrganicMatter;
using System;
using System.Collections.Generic;

namespace CulinarySite.Common.Dtos.Recipe
{
    public class UpdateRecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string Content { get; set; }
        public int DishId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public List<UpdateIngredientDto> Ingredients { get; set; } = new List<UpdateIngredientDto>();
        public List<UpdateOrganicMatterDto> OrganicMatters { get; set; } = new List<UpdateOrganicMatterDto>();
        public List<UpdateCookingStageDto> CookingStages { get; set; } = new List<UpdateCookingStageDto>();
        public string ImageUrl { get; set; }

    }
}
