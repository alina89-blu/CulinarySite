namespace CulinarySite.Domain.Entities
{
    public class CookingStage : BaseEntity
    {
        public string Content { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string ImageUrl { get; set; }
    }
}
