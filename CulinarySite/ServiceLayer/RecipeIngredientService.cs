using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.RecipeIngredient;
using System.Linq;

namespace ServiceLayer
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IReadOnlyGenericRepository<RecipeIngredient> recipeIngredientReadOnlyRepository;
        private readonly IWriteGenericRepository<RecipeIngredient> recipeIngredientWriteRepository;
        public RecipeIngredientService(
            IReadOnlyGenericRepository<RecipeIngredient> recipeIngredientReadOnlyRepository,
            IWriteGenericRepository<RecipeIngredient> recipeIngredientWriteRepository)
        {
            this.recipeIngredientReadOnlyRepository = recipeIngredientReadOnlyRepository;
            this.recipeIngredientWriteRepository = recipeIngredientWriteRepository;
        }

        public void CreateRecipeIngredient(CreateRecipeIngredientModel createRecipeIngredientModel)
        {

            var recipeIngredient = new RecipeIngredient
            {
                IngredientId = createRecipeIngredientModel.IngredientId,
                Unit = createRecipeIngredientModel.Unit,
                Quantity = createRecipeIngredientModel.Quantity
            };
            this.recipeIngredientWriteRepository.Create(recipeIngredient);
            this.recipeIngredientWriteRepository.Save();
        }

        public void UpdateRecipeIngredient(UpdateRecipeIngredientModel updateRecipeIngredientModel)//
        {
            var recipeIngredientsId = this.recipeIngredientReadOnlyRepository.GetItemList().Select(x => x.Id);
            var recipeIngredient = new RecipeIngredient();

            if (recipeIngredientsId.Contains(updateRecipeIngredientModel.RecipeIngredientId))
            {
                // recipeIngredient = this.recipeIngredientWriteRepository.GetItem(updateRecipeIngredientModel.RecipeIngredientId);
                recipeIngredient = new RecipeIngredient
                {
                    Id = updateRecipeIngredientModel.RecipeIngredientId,
                    IngredientId = updateRecipeIngredientModel.IngredientId,
                    Unit = updateRecipeIngredientModel.Unit,
                    Quantity = updateRecipeIngredientModel.Quantity,
                };
                this.recipeIngredientWriteRepository.Update(recipeIngredient);
                this.recipeIngredientWriteRepository.Save();
            }
            else
            {
                recipeIngredient = new RecipeIngredient
                {
                    IngredientId = updateRecipeIngredientModel.IngredientId,
                    Unit = updateRecipeIngredientModel.Unit,
                    Quantity = updateRecipeIngredientModel.Quantity,
                };
                this.recipeIngredientWriteRepository.Create(recipeIngredient);
                this.recipeIngredientWriteRepository.Save();
            }
        }

        public void DeleteRecipeIngredient(int id)
        {
            this.recipeIngredientWriteRepository.Delete(id);
            this.recipeIngredientWriteRepository.Save();
        }

        public IEnumerable<RecipeIngredientListModel> GetRecipeIngredientList(bool withRelated)
        {
            IEnumerable<RecipeIngredient> recipeIngredients;
            List<RecipeIngredientListModel> recipeIngredientListModels = new List<RecipeIngredientListModel>();
            if (withRelated)
            {
                recipeIngredients = this.recipeIngredientReadOnlyRepository.GetItemListWithInclude(
                    x => x.Ingredient,
                    x => x.Recipes);
                foreach (var recipeIngredient in recipeIngredients)
                {
                    recipeIngredientListModels.Add(new RecipeIngredientListModel
                    {
                        RecipeIngredientId = recipeIngredient.Id,
                        Unit = recipeIngredient.Unit,
                        Quantity = recipeIngredient.Quantity,
                        IngredientName = recipeIngredient.Ingredient.Name,
                        //   RecipeName=recipeIngredient.Recipe.Name
                    });
                }
                return recipeIngredientListModels;
            }
            recipeIngredients = this.recipeIngredientReadOnlyRepository.GetItemList();
            foreach (var recipeIngredient in recipeIngredients)
            {
                recipeIngredientListModels.Add(new RecipeIngredientListModel
                {
                    RecipeIngredientId = recipeIngredient.Id,
                    Unit = recipeIngredient.Unit,
                    Quantity = recipeIngredient.Quantity
                });
            }
            return recipeIngredientListModels;
        }

        public RecipeIngredientDetailModel GetRecipeIngredient(int id, bool withRelated)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            RecipeIngredientDetailModel recipeIngredientDetailModel = new RecipeIngredientDetailModel();

            if (withRelated)
            {
                recipeIngredient = this.recipeIngredientReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Ingredient,
                    x => x.Recipes);
                recipeIngredientDetailModel = new RecipeIngredientDetailModel
                {
                    RecipeIngredientId = recipeIngredient.Id,
                    IngredientId = recipeIngredient.IngredientId,
                    Unit = recipeIngredient.Unit,
                    Quantity = recipeIngredient.Quantity,
                    //  RecipeId=recipeIngredient.RecipeId
                };
                return recipeIngredientDetailModel;
            }
            recipeIngredient = this.recipeIngredientReadOnlyRepository.GetItem(id);
            recipeIngredientDetailModel = new RecipeIngredientDetailModel
            {
                RecipeIngredientId = recipeIngredient.Id,
                // IngredientId = recipeIngredient.IngredientId,
                Unit = recipeIngredient.Unit,
                Quantity = recipeIngredient.Quantity
            };
            return recipeIngredientDetailModel;
        }
    }
}
