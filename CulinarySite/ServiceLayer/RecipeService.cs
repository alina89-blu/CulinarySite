using Database;
using Repositories;
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.Recipe;
using ServiceLayer.ViewModels.Tag;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class RecipeService : IRecipeService
    {
        private readonly IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository;
        private readonly IWriteGenericRepository<Recipe> recipeWriteRepository;
        private readonly IWriteGenericRepository<Ingredient> ingredientWriteRepository;
        // private readonly IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository;
        private readonly IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository;
        public RecipeService(
            IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository,
            IWriteGenericRepository<Recipe> recipeWriteRepository,
            IWriteGenericRepository<Ingredient> ingredientWriteRepository,
            //IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository,
            IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository)
        {
            this.recipeReadOnlyRepository = recipeReadOnlyRepository;
            this.recipeWriteRepository = recipeWriteRepository;
            this.ingredientWriteRepository = ingredientWriteRepository;
            // this.ingredientReadOnlyRepository = ingredientReadOnlyRepository;
            this.ingredientReadOnlyRepository = ingredientReadOnlyRepository;
        }

        public void CreateRecipe(CreateRecipeModel createRecipeModel)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var ingredient in createRecipeModel.Ingredients)
            {
                if (ingredient.Name != null)
                {
                    ingredients.Add(new Ingredient
                    {
                        Name = ingredient.Name,
                        Unit = ingredient.Unit,
                        Quantity = ingredient.Quantity
                    });
                }

            }

            List<OrganicMatter> organicMatters = new List<OrganicMatter>();
            foreach (var organicMatter in createRecipeModel.OrganicMatters)
            {
                organicMatters.Add(new OrganicMatter
                {
                    Name = organicMatter.Name,
                    Unit = organicMatter.Unit,
                    Quantity = organicMatter.Quantity
                });
            }

            List<CookingStage> cookingStages = new List<CookingStage>();
            foreach (var cookingStage in createRecipeModel.CookingStages)
            {
                cookingStages.Add(new CookingStage
                {
                    Content = cookingStage.Content,
                    RecipeId = cookingStage.RecipeId
                });
            }

            List<Tag> tags = new List<Tag>();
            foreach (var tag in createRecipeModel.Tags)
            {
                tags.Add(new Tag
                {
                    Text = tag.Text
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
                Ingredients = ingredients,
                OrganicMatters = organicMatters,
                CookingStages = cookingStages,
                Tags = tags
            };
            this.recipeWriteRepository.Create(recipe);
            this.recipeWriteRepository.Save();
        }

        public void UpdateIngredient(UpdateIngredientModel updateIngredientModel)//
        {
            var ingredientsId = this.ingredientReadOnlyRepository.GetItemList().Select(x => x.Id);
            var ingredient = new Ingredient();

            if (ingredientsId.Contains(updateIngredientModel.IngredientId))
            {

                ingredient = new Ingredient
                {
                    Id = updateIngredientModel.IngredientId,
                    Name = updateIngredientModel.Name,
                    Unit = updateIngredientModel.Unit,
                    Quantity = updateIngredientModel.Quantity,
                };
                this.ingredientWriteRepository.Update(ingredient);
                this.ingredientWriteRepository.Save();
            }
            else
            {
                ingredient = new Ingredient
                {
                    Name = updateIngredientModel.Name,
                    Unit = updateIngredientModel.Unit,
                    Quantity = updateIngredientModel.Quantity,
                };
                this.ingredientWriteRepository.Create(ingredient);
                this.ingredientWriteRepository.Save();
            }
        }
        public void UpdateRecipe(UpdateRecipeModel updateRecipeModel)
        {
            /*   var ingredients = updateRecipeModel
             .Ingredients
             .Select(x => this.ingredientWriteRepository.GetItem(x.IngredientId))
             .ToList();
   */


          

            /*List<Ingredient> ingredients = new List<Ingredient>();

            foreach (var ingredient in updateRecipeModel.Ingredients)
            {               
                    ingredients.Add(new Ingredient
                    {
                        Id = ingredient.IngredientId,
                        Name = ingredient.Name,
                        Unit = ingredient.Unit,
                        Quantity = ingredient.Quantity
                    });              
            }*/

            List<OrganicMatter> organicMatters = new List<OrganicMatter>();

            foreach (var organicMatter in updateRecipeModel.OrganicMatters)
            {
                organicMatters.Add(new OrganicMatter
                {
                    Id = organicMatter.OrganicMatterId,
                    Name = organicMatter.Name,
                    Unit = organicMatter.Unit,
                    Quantity = organicMatter.Quantity
                });
            }

            List<CookingStage> cookingStages = new List<CookingStage>();

            foreach (var cookingStage in updateRecipeModel.CookingStages)
            {
                cookingStages.Add(new CookingStage
                {
                    Id = cookingStage.CookingStageId,
                    Content = cookingStage.Content,
                    RecipeId = cookingStage.RecipeId
                });
            }

            List<Tag> tags = new List<Tag>();

            foreach (var tag in updateRecipeModel.Tags)
            {
                tags.Add(new Tag
                {
                    Id = tag.TagId,
                    Text = tag.Text
                });
            }

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
              //  Ingredients = ingredients,
                OrganicMatters = organicMatters,
                CookingStages = cookingStages,
                Tags = tags
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
                    x => x.Ingredients,
                    x => x.OrganicMatters,
                    x => x.CookingStages,
                    x => x.Tags
                    );

                foreach (var recipe in recipes)
                {
                    var ingredients = new List<IngredientModel>();

                    foreach (var ingredient in recipe.Ingredients)
                    {
                        ingredients.Add(new IngredientModel
                        {
                            IngredientId = ingredient.Id,
                            Name = ingredient.Name,
                            Unit = ingredient.Unit,
                            Quantity = ingredient.Quantity,
                        });
                    }

                    var organicMatters = new List<OrganicMatterModel>();

                    foreach (var organicMatter in recipe.OrganicMatters)
                    {
                        organicMatters.Add(new OrganicMatterModel
                        {
                            OrganicMatterId = organicMatter.Id,
                            Name = organicMatter.Name,
                            Unit = organicMatter.Unit,
                            Quantity = organicMatter.Quantity,
                        });
                    }

                    var cookingStages = new List<CookingStageModel>();

                    foreach (var cookingStage in recipe.CookingStages)
                    {
                        cookingStages.Add(new CookingStageModel
                        {
                            CookingStageId = cookingStage.Id,
                            Content = cookingStage.Content,
                            RecipeId = cookingStage.RecipeId
                        });
                    }

                    var tags = new List<TagModel>();

                    foreach (var tag in recipe.Tags)
                    {
                        tags.Add(new TagModel
                        {
                            TagId = tag.Id,
                            Text = tag.Text
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
                        Ingredients = ingredients,
                        OrganicMatters = organicMatters,
                        CookingStages = cookingStages,
                        Tags = tags
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
                    Content = recipe.Content
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
                    x => x.Dish,
                    x => x.Author,
                    x => x.Book,
                    x => x.Ingredients,
                    x => x.OrganicMatters,
                    x => x.CookingStages,
                    x => x.Tags
                   );

                List<IngredientModel> ingredientModels = new List<IngredientModel>();

                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredientModels.Add(new IngredientModel
                    {
                        IngredientId = ingredient.Id,
                        Name = ingredient.Name,
                        Unit = ingredient.Unit,
                        Quantity = ingredient.Quantity
                    });
                }

                List<OrganicMatterModel> organicMatterModels = new List<OrganicMatterModel>();

                foreach (var organicMatter in recipe.OrganicMatters)
                {
                    organicMatterModels.Add(new OrganicMatterModel
                    {
                        OrganicMatterId = organicMatter.Id,
                        Name = organicMatter.Name,
                        Unit = organicMatter.Unit,
                        Quantity = organicMatter.Quantity
                    });
                }

                List<CookingStageModel> cookingStageModels = new List<CookingStageModel>();

                foreach (var cookingStage in recipe.CookingStages)
                {
                    cookingStageModels.Add(new CookingStageModel
                    {
                        CookingStageId = cookingStage.Id,
                        Content = cookingStage.Content,
                        RecipeId = cookingStage.RecipeId
                        //RecipeId = recipe.Id                       
                    });
                }

                List<TagModel> tagModels = new List<TagModel>();

                foreach (var tag in recipe.Tags)
                {
                    tagModels.Add(new TagModel
                    {
                        TagId = tag.Id,
                        Text = tag.Text
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
                    Ingredients = ingredientModels,
                    OrganicMatters = organicMatterModels,
                    CookingStages = cookingStageModels,
                    Tags = tagModels
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

