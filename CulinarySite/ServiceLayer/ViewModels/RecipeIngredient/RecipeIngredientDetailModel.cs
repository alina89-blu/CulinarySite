
namespace ServiceLayer.ViewModels.RecipeIngredient
{
    public class RecipeIngredientDetailModel
    {
        public int RecipeIngredientId { get; set; }
        public int IngredientId { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
       
    }
}
