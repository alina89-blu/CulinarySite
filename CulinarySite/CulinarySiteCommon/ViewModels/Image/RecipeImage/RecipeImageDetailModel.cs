
namespace CulinarySite.Common.ViewModels.Image.RecipeImage
{
  public  class RecipeImageDetailModel
    {
        public int RecipeImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? RecipeId { get; set; }
    }
}
