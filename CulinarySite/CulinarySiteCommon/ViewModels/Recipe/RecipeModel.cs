
using ServiceLayer.ViewModels.Image.RecipeImage;

namespace ServiceLayer.ViewModels.Recipe
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public RecipeImageModel Image { get; set; }
    }
}
