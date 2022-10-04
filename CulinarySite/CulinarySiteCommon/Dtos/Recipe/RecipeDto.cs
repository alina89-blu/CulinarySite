
using ServiceLayer.Dtos.Image.RecipeImage;

namespace ServiceLayer.Dtos.Recipe
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public RecipeImageDto Image { get; set; }
    }
}
