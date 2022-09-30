using Repositories;
using System.Collections.Generic;
using AutoMapper;
using ServiceLayer.Dtos.Recipe;
using Database.Entities;

namespace ServiceLayer
{
    public class RecipeService : IRecipeService
    {
        private readonly IReadOnlyGenericRepository<Recipe> _recipeReadOnlyRepository;
        private readonly IWriteGenericRepository<Recipe> _recipeWriteRepository;        
        private readonly IMapper _mapper;
        public RecipeService(
            IReadOnlyGenericRepository<Recipe> recipeReadOnlyRepository,
            IWriteGenericRepository<Recipe> recipeWriteRepository,        
            IMapper mapper)
        {
            _recipeReadOnlyRepository = recipeReadOnlyRepository;
            _recipeWriteRepository = recipeWriteRepository;                      
            _mapper = mapper;
        }

        public void CreateRecipe(CreateRecipeDto createRecipeDto)
        {
            Recipe recipe = _mapper.Map<Recipe>(createRecipeDto);

            _recipeWriteRepository.Create(recipe);
            _recipeWriteRepository.Save();
        }

        public void UpdateRecipe(UpdateRecipeDto updateRecipeDto)
        {
            Recipe recipe = _mapper.Map<Recipe>(updateRecipeDto);

            _recipeWriteRepository.Update(recipe);
            _recipeWriteRepository.Save();
        }

        public void DeleteRecipe(int id)
        {
            _recipeWriteRepository.Delete(id);
            _recipeWriteRepository.Save();
        }

        public IEnumerable<RecipeListDto> GetRecipeList(bool withRelated)
        {
            IEnumerable<Recipe> recipes;
            var recipeListDtos = new List<RecipeListDto>();

            if (withRelated)
            {
                recipes = _recipeReadOnlyRepository.GetItemListWithInclude(
                    x => x.Dish,
                    x => x.Author,
                    x => x.Book,
                    x => x.Ingredients,
                    x => x.OrganicMatters,
                    x => x.CookingStages,
                    x => x.Tags,
                    x => x.Image
                    );

                foreach (var recipe in recipes)
                {
                    recipeListDtos.Add(_mapper.Map<RecipeListDto>(recipe));
                }

                return recipeListDtos;
            }

            recipes = _recipeReadOnlyRepository.GetItemList();

            foreach (var recipe in recipes)
            {
                recipeListDtos.Add(_mapper.Map<RecipeListDto>(recipe));
            }
            return recipeListDtos;
        }

        public RecipeDetailDto GetRecipe(int id, bool withRelated)
        {
            var recipe = new Recipe();
            var recipeDetailDto = new RecipeDetailDto();

            if (withRelated)
            {
                recipe = _recipeReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Dish,
                    x => x.Author,
                    x => x.Book,
                    x => x.Ingredients,
                    x => x.OrganicMatters,
                    x => x.CookingStages,
                    x => x.Tags,
                    x => x.Image
                   );

                recipeDetailDto = _mapper.Map<RecipeDetailDto>(recipe);

                return recipeDetailDto;
            }

            recipe = _recipeReadOnlyRepository.GetItem(id);

            recipeDetailDto = _mapper.Map<RecipeDetailDto>(recipe);

            return recipeDetailDto;
        }
    }
}

