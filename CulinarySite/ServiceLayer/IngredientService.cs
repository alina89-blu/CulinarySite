using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Ingredient;

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

        public void CreateIngredient(CreateIngredientModel createIngredientModel)
        {
            var ingredient = new Ingredient
            {
                Name = createIngredientModel.Name
            };
            this.ingredientWriteRepository.Create(ingredient);
            this.ingredientWriteRepository.Save();
        }

        public void UpdateIngredient(UpdateIngredientModel updateIngredientModel)
        {
            var ingredient = new Ingredient
            {
                Id = updateIngredientModel.IngredientId,
                Name = updateIngredientModel.Name
            };
            this.ingredientWriteRepository.Update(ingredient);
            this.ingredientWriteRepository.Save();
        }

        public void DeleteIngredient(int id)
        {
            this.ingredientWriteRepository.Delete(id);
            this.ingredientWriteRepository.Save();
        }

        public IEnumerable<IngredientListModel> GetIngredientList(bool withRelated)
        {
            IEnumerable<Ingredient> ingredients;
            List<IngredientListModel> ingredientListModels = new List<IngredientListModel>();
            if (withRelated)
            {
                ingredients = this.ingredientReadOnlyRepository.GetItemListWithInclude();
                foreach (var ingredient in ingredients)
                {
                    ingredientListModels.Add(new IngredientListModel
                    {
                        IngredientId = ingredient.Id,
                        Name = ingredient.Name
                    });
                }
                return ingredientListModels;
            }
            ingredients = this.ingredientReadOnlyRepository.GetItemList();
            foreach (var ingredient in ingredients)
            {
                ingredientListModels.Add(new IngredientListModel
                {
                    IngredientId = ingredient.Id,
                    Name = ingredient.Name
                });
            }
            return ingredientListModels;
        }

        public IngredientDetailModel GetIngredient(int id, bool withRelated)
        {
            Ingredient ingredient = new Ingredient();
            IngredientDetailModel ingredientDetailModel = new IngredientDetailModel();
            if (withRelated)
            {
                ingredient = this.ingredientReadOnlyRepository.GetItemWithInclude(
                                x => x.Id == id);
                ingredientDetailModel = new IngredientDetailModel
                {
                    IngredientId = ingredient.Id,
                    Name = ingredient.Name
                };
                return ingredientDetailModel;
            }
            ingredient = this.ingredientReadOnlyRepository.GetItem(id);
            ingredientDetailModel = new IngredientDetailModel
            {
                IngredientId = ingredient.Id,
                Name = ingredient.Name
            };
            return ingredientDetailModel;
        }
    }
}
