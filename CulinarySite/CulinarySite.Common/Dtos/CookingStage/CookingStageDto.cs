
namespace CulinarySite.Common.Dtos.CookingStage
{
    public class CookingStageDto
    {
        public int CookingStageId { get; set; }
        public string Content { get; set; }
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; }
    }
}
