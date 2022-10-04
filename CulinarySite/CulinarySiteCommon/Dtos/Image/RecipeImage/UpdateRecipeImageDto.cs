
namespace ServiceLayer.Dtos.Image.RecipeImage
{
    public class UpdateRecipeImageDto
    {
        public int RecipeImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int RecipeId { get; set; }
    }
}
