﻿
using ServiceLayer.ViewModels.Recipe;
using System.Collections.Generic;

namespace ServiceLayer.ViewModels.Dish
{
    public class DishDetailModel
    {
        public int DishId { get; set; }
        public string Category { get; set; }
        //public List<RecipeModel> Recipes { get; set; }
        public List<RecipeDetailModel> Recipes { get; set; }
    }
}