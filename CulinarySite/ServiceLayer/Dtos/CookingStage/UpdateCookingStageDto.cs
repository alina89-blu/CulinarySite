
namespace ServiceLayer.Dtos.CookingStage
{
    public class UpdateCookingStageDto
    {
        public int CookingStageId { get; set; }
        public string Content { get; set; }
        public int RecipeId { get; set; }
    }
}
