
using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Common.ViewModels.CookingStage
{
    public class CreateUpdateCookingStageBaseModel
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; }
    }
}
