using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.Dtos.Ingredient;
using AutoMapper;

namespace ServiceLayer
{
    public class IngredientService : IIngredientService
    {
        private readonly IReadOnlyGenericRepository<Ingredient> _ingredientReadOnlyRepository;
        private readonly IWriteGenericRepository<Ingredient> _ingredientWriteRepository;
        private readonly IMapper _mapper;
        public IngredientService(
            IReadOnlyGenericRepository<Ingredient> ingredientReadOnlyRepository,
            IWriteGenericRepository<Ingredient> ingredientWriteRepository,
             IMapper mapper)
        {
            _ingredientReadOnlyRepository = ingredientReadOnlyRepository;
            _ingredientWriteRepository = ingredientWriteRepository;
            _mapper = mapper;
        }

        public void CreateIngredient(CreateIngredientDto createIngredientDto)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(createIngredientDto);

            _ingredientWriteRepository.Create(ingredient);
            _ingredientWriteRepository.Save();
        }

        public void UpdateIngredient(UpdateIngredientDto updateIngredientDto)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(updateIngredientDto);

            _ingredientWriteRepository.Update(ingredient);
            _ingredientWriteRepository.Save();
        }

        public void DeleteIngredient(int id)
        {
            _ingredientWriteRepository.Delete(id);
            _ingredientWriteRepository.Save();
        }

        public IEnumerable<IngredientListDto> GetIngredientList()
        {
            IEnumerable<Ingredient> ingredients = _ingredientReadOnlyRepository.GetItemList();

            var ingredientListDtos = new List<IngredientListDto>();

            foreach (var ingredient in ingredients)
            {
                ingredientListDtos.Add(_mapper.Map<IngredientListDto>(ingredient));
            }
            return ingredientListDtos;
        }

        public IngredientDetailDto GetIngredient(int id)
        {
            Ingredient ingredient = _ingredientReadOnlyRepository.GetItem(id);
            IngredientDetailDto ingredientDetailDto = _mapper.Map<IngredientDetailDto>(ingredient);

            return ingredientDetailDto;
        }

        /* public void UpdateIngredient(UpdateIngredientModel updateIngredientModel)//
         {
             var ingredientsId = ingredientReadOnlyRepository.GetItemList().Select(x => x.Id);
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
                 ingredientWriteRepository.Update(ingredient);
                 ingredientWriteRepository.Save();
             }
             else
             {
                 ingredient = new Ingredient
                 {
                     Name = updateIngredientModel.Name,
                     Unit = updateIngredientModel.Unit,
                     Quantity = updateIngredientModel.Quantity,
                 };
                 ingredientWriteRepository.Create(ingredient);
                 ingredientWriteRepository.Save();
             }
         }*/
    }
}
