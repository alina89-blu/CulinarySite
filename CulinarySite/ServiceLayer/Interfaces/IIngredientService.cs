using CulinarySite.Common.Dtos.Ingredient;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
