﻿
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.Restaurant
{
    public class CreateUpdateRestaurantBaseModel
    {
       // [MaxLength(5)]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}