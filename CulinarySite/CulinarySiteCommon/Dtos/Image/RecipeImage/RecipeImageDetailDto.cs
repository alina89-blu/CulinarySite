
namespace CulinarySite.Common.Dtos.Image.RecipeImage
{
  public  class RecipeImageDetailDto
    {
        public int RecipeImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? RecipeId { get; set; }
    }
}
