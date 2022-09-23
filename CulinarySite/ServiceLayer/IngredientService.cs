using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Ingredient;
using System.Linq;

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
                    Name = createIngredientModel.Name,
                    Unit = createIngredientModel.Unit,
                    Quantity = createIngredientModel.Quantity
                };
                this.ingredientWriteRepository.Create(ingredient);
                this.ingredientWriteRepository.Save();                                    
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
                    Name= updateIngredientModel.Name,
                    Unit = updateIngredientModel.Unit,
                    Quantity = updateIngredientModel.Quantity,
                };
                this.ingredientWriteRepository.Create(ingredient);
                this.ingredientWriteRepository.Save();
            }
        }

        public void DeleteIngredient(int id)
        {
            this.ingredientWriteRepository.Delete(id);
            this.ingredientWriteRepository.Save();
        }

        public IEnumerable<IngredientListModel> GetIngredientList()
        {
            IEnumerable<Ingredient> ingredients= this.ingredientReadOnlyRepository.GetItemList();
            List<IngredientListModel> ingredientListModels = new List<IngredientListModel>();
                               
            foreach (var ingredient in ingredients)
            {
                ingredientListModels.Add(new IngredientListModel
                {
                    IngredientId = ingredient.Id,
                    Name = ingredient.Name,
                    Unit = ingredient.Unit,
                    Quantity = ingredient.Quantity,
                });
            }
            return ingredientListModels;
        }

        public IngredientDetailModel GetIngredient(int id)
        {
            Ingredient ingredient =  this.ingredientReadOnlyRepository.GetItem(id);
            IngredientDetailModel ingredientDetailModel = new IngredientDetailModel()                              
            {
                IngredientId = ingredient.Id,
                Name = ingredient.Name,
                Unit = ingredient.Unit,
                Quantity = ingredient.Quantity
            };
            return ingredientDetailModel;
        }
    }
}
