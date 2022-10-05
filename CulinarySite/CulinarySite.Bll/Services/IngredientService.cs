using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Ingredient;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
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
            var ingredientListDtos = ingredients.Select(x => _mapper.Map<IngredientListDto>(x));            

            return ingredientListDtos;
        }

        public IngredientDetailDto GetIngredient(int id)
        {
            Ingredient ingredient = _ingredientReadOnlyRepository.GetItem(id);
            IngredientDetailDto ingredientDetailDto = _mapper.Map<IngredientDetailDto>(ingredient);

            return ingredientDetailDto;
        }
      
    }
}
