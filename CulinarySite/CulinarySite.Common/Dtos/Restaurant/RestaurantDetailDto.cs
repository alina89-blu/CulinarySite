﻿using CulinarySite.Common.Dtos.Telephone;
using System.Collections.Generic;

namespace CulinarySite.Common.Dtos.Restaurant
{
    public class RestaurantDetailDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public List<TelephoneDto> Telephones { get; set; } = new List<TelephoneDto>();
    }
}
