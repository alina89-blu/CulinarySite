using Database;
using Repositories;
using ServiceLayer.ViewModels.Recipe;
using ServiceLayer.ViewModels.RecipeIngredient;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class RecipeService : IRecipeService
    {
        private readonly IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository;
        private readonly IWriteGenericRepository<Recipe> recipeWriteRepository;
        private readonly IWriteGenericRepository<RecipeIngredient> recipeIngredientWriteRepository;
        public RecipeService(
            IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository,
            IWriteGenericRepository<Recipe> recipeWriteRepository,
            IWriteGenericRepository<RecipeIngredient> recipeIngredientWriteRepository)
        {
            this.recipeReadOnlyRepository = recipeReadOnlyRepository;
            this.recipeWriteRepository = recipeWriteRepository;
            this.recipeIngredientWriteRepository = recipeIngredientWriteRepository;
        }

        //exAMPLE
        /*public void CreateRecipe(RecipeCreateModel recipeBla)
        {
            var receipe = new Recipe { ServingsNumber = recipeBla.ServingsNumber };

            this.recipeWriteRepository.Create(receipe);
            this.recipeWriteRepository.Save();           
        }*/
        public void CreateRecipe(CreateRecipeModel createRecipeModel)
        {
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            foreach (var recipeIngredient in createRecipeModel.RecipeIngredients)
            {
                recipeIngredients.Add(new RecipeIngredient
                {
                    Id = recipeIngredient.RecipeIngredientId,
                    IngredientId = recipeIngredient.IngredientId,
                    Unit = recipeIngredient.Unit,
                    Quantity = recipeIngredient.Quantity
                });
            }

            List<RecipeOrganicMatter> recipeOrganicMatters = new List<RecipeOrganicMatter>();
            foreach (var recipeOrganicMatter in createRecipeModel.OrganicMatterRecipes)
            {
                recipeOrganicMatters.Add(new RecipeOrganicMatter
                {
                    Id = recipeOrganicMatter.RecipeOrganicMatterId,
                    OrganicMatterId = recipeOrganicMatter.OrganicMatterId,
                    Unit = recipeOrganicMatter.Unit,
                    Quantity = recipeOrganicMatter.Quantity
                });
            }

            var recipe = new Recipe
            {
                Name = createRecipeModel.Name,
                ServingsNumber = createRecipeModel.ServingsNumber,
                CookingTime = createRecipeModel.CookingTime,
                DifficultyLevel = createRecipeModel.DifficultyLevel,
                Content = createRecipeModel.Content,
                DishId = createRecipeModel.DishId,
                AuthorId = createRecipeModel.AuthorId,
                BookId = createRecipeModel.BookId,
                RecipeIngredients = recipeIngredients,
                RecipeOrganicMatters = recipeOrganicMatters
            };
            this.recipeWriteRepository.Create(recipe);
            this.recipeWriteRepository.Save();
        }

        public void UpdateRecipe(UpdateRecipeModel updateRecipeModel)
        {
            var recipeIngredients = updateRecipeModel
                .RecipeIngredients
                .Select(x => this.recipeIngredientWriteRepository.GetItem(x.RecipeIngredientId))
                .ToList();
            var recipe = new Recipe
            {
                Id = updateRecipeModel.RecipeId,//
                Name = updateRecipeModel.Name,
                ServingsNumber = updateRecipeModel.ServingsNumber,
                CookingTime = updateRecipeModel.CookingTime,
                DifficultyLevel = updateRecipeModel.DifficultyLevel,
                Content = updateRecipeModel.Content,
                DishId = updateRecipeModel.DishId,
                AuthorId = updateRecipeModel.AuthorId,
                BookId = updateRecipeModel.BookId,
                RecipeIngredients = recipeIngredients
            };
            this.recipeWriteRepository.Update(recipe);
            this.recipeWriteRepository.Save();
        }

        public void DeleteRecipe(int id)
        {
            this.recipeWriteRepository.Delete(id);
            this.recipeWriteRepository.Save();
        }

        public IEnumerable<RecipeListModel> GetRecipeList(bool withRelated)
        {
            IEnumerable<Recipe> recipes;
            List<RecipeListModel> recipeListModels = new List<RecipeListModel>();

            if (withRelated)
            {
                recipes = this.recipeReadOnlyRepository.GetItemListWithInclude(
                    x => x.Dish,
                    x => x.Author,
                    x => x.Book,
                    x => x.RecipeIngredients);

                foreach (var recipe in recipes)
                {
                    var recipeIngredientModels = new List<RecipeIngredientModel>();

                    foreach (var recipeIngredient in recipe.RecipeIngredients)
                    {
                        recipeIngredientModels.Add(new RecipeIngredientModel
                        {
                            RecipeIngredientId = recipeIngredient.Id,
                            IngredientId = recipeIngredient.IngredientId,
                            Quantity = recipeIngredient.Quantity,
                            Unit = recipeIngredient.Unit
                        });
                    }
                    recipeListModels.Add(new RecipeListModel
                    {
                        RecipeId = recipe.Id,
                        Name = recipe.Name,
                        ServingsNumber = recipe.ServingsNumber,
                        CookingTime = recipe.CookingTime,
                        DifficultyLevel = recipe.DifficultyLevel,
                        Content = recipe.Content,
                        DishCategory = recipe.Dish.Category,
                        AuthorName = recipe.Author.Name,
                        BookName = recipe.Book?.Name,
                        RecipeIngredients = recipeIngredientModels
                    });
                }
                return recipeListModels;
            }
            recipes = this.recipeReadOnlyRepository.GetItemList();
            foreach (var recipe in recipes)
            {
                recipeListModels.Add(new RecipeListModel
                {
                    RecipeId = recipe.Id,
                    Name = recipe.Name,
                    ServingsNumber = recipe.ServingsNumber,
                    CookingTime = recipe.CookingTime,
                    DifficultyLevel = recipe.DifficultyLevel,
                    Content = recipe.Content,
                });
            }
            return recipeListModels;
        }

        public RecipeDetailModel GetRecipe(int id, bool withRelated)
        {
            var recipe = new Recipe();
            RecipeDetailModel recipeDetailModel = new RecipeDetailModel();

            if (withRelated)
            {
                recipe = this.recipeReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.RecipeIngredients,
                    //x => x.OrganicMatters,
                    x => x.CookingStages,
                    x => x.Tags,
                    x => x.Dish
                   );

                List<RecipeIngredientModel> recipeIngredientModels = new List<RecipeIngredientModel>();
                foreach (var recipeIngredient in recipe.RecipeIngredients)
                {
                    recipeIngredientModels.Add(new RecipeIngredientModel
                    {
                        RecipeIngredientId = recipeIngredient.Id,
                        IngredientId = recipeIngredient.IngredientId,
                        Quantity = recipeIngredient.Quantity,
                        Unit = recipeIngredient.Unit
                    });
                }
                recipeDetailModel = new RecipeDetailModel
                {
                    RecipeId = recipe.Id,
                    Name = recipe.Name,
                    ServingsNumber = recipe.ServingsNumber,
                    CookingTime = recipe.CookingTime,
                    DifficultyLevel = recipe.DifficultyLevel,
                    Content = recipe.Content,
                    DishId = recipe.DishId,
                    AuthorId = recipe.AuthorId,
                    BookId = recipe.BookId,
                    RecipeIngredients = recipeIngredientModels
                };
                return recipeDetailModel;
            }
            recipe = this.recipeReadOnlyRepository.GetItem(id);
            recipeDetailModel = new RecipeDetailModel
            {
                RecipeId = recipe.Id,
                Name = recipe.Name,
                ServingsNumber = recipe.ServingsNumber,
                CookingTime = recipe.CookingTime,
                DifficultyLevel = recipe.DifficultyLevel,
                Content = recipe.Content,
            };
            return recipeDetailModel;
        }
    }
}

