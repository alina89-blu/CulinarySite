using System.Collections.Generic;
using ServiceLayer.Dtos.Ingredient;

namespace ServiceLayer
{
    public interface IIngredientService
    {
        void CreateIngredient(CreateIngredientDto createIngredientDto);
        void UpdateIngredient(UpdateIngredientDto updateIngredientDto);
        void DeleteIngredient(int id);
        IEnumerable<IngredientListDto> GetIngredientList();
        IngredientDetailDto GetIngredient(int id);
    }
}
