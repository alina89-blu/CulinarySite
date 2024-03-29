﻿using System;
using System.Collections.Generic;

namespace CulinarySite.Domain.Entities
{
    public class Recipe : BaseEntity
    {        
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public string DifficultyLevel { get; set; }    
        public string Content { get; set; } 
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<OrganicMatter> OrganicMatters { get; set; } = new List<OrganicMatter>();              
        public List<CookingStage> CookingStages { get; set; } = new List<CookingStage>();        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public string ImageUrl { get; set; }
    }
}
