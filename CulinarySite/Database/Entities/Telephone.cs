﻿using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Telephone : BaseEntity
    {
        [Required]
        public string Number { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}