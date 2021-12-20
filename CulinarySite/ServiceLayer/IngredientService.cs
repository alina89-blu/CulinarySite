using Database;
using Repositories;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class IngredientService : IIngredientService
    {
        private readonly IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository;
        private readonly IWriteGenericRepository<Ingredient> ingredientWriteRepository;
        public IngredientService(
            IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository,
            IWriteGenericRepository<Ingredient> ingredientWriteRepository)
        {
            this.ingredientReadOnlyRepository = ingredientReadOnlyRepository;
            this.ingredientWriteRepository = ingredientWriteRepository;
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            this.ingredientWriteRepository.Create(ingredient);
            this.ingredientWriteRepository.Save();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            this.ingredientWriteRepository.Update(ingredient);
            this.ingredientWriteRepository.Save();
        }

        public void DeleteIngredient(int id)
        {
            this.ingredientWriteRepository.Delete(id);
            this.ingredientWriteRepository.Save();
        }

        public IEnumerable<Ingredient> GetIngredientListWithInclude()
        {
            return this.ingredientReadOnlyRepository.GetItemListWithInclude(
                x => x.Recipes);
        }

        public Ingredient GetIngredientWithInclude(int id)
        {
            return this.ingredientReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipes);
        }
    }
}
