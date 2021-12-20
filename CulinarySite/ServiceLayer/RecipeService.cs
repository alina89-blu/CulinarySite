using Database;
using Repositories;
using System.Collections.Generic;


namespace ServiceLayer
{
    public class RecipeService : IRecipeService
    {
        private readonly IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository;
        private readonly IWriteGenericRepository<Recipe> recipeWriteRepository;

        public RecipeService(
            IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository,
            IWriteGenericRepository<Recipe> recipeWriteRepository)
        {
            this.recipeReadOnlyRepository = recipeReadOnlyRepository;
            this.recipeWriteRepository = recipeWriteRepository;
        }
        public void CreateRecipe(Recipe recipe)
        {
            this.recipeWriteRepository.Create(recipe);
            this.recipeWriteRepository.Save();
        }
        public void UpdateRecipe(Recipe recipe)
        {
            this.recipeWriteRepository.Update(recipe);
            this.recipeWriteRepository.Save();
        }
        public void DeleteRecipe(int id)
        {
            this.recipeWriteRepository.Delete(id);
            this.recipeWriteRepository.Save();
        }
        public IEnumerable<Recipe> GetRecipeListWithInclude()
        {
            return this.recipeReadOnlyRepository.GetItemListWithInclude(
                x => x.Ingredients,
                x => x.OrganicMatters,
                x => x.CookingStages,
                x => x.Tags,
                x => x.Author,
                x => x.Book,
                x => x.Dish);
        }
        public Recipe GetRecipeWithInclude(int id)
        {
            return this.recipeReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Ingredients,
                x => x.OrganicMatters,
                x => x.CookingStages,
                x => x.Tags,
                x => x.Author,
                x => x.Book,
                x => x.Dish);
        }
    }
}


