﻿
namespace ServiceLayer.Dtos.Image.DishImage
{
  public  class DishImageDetailDto
    {
        public int DishImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? DishId { get; set; }
    }
}