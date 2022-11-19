using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Recipe;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;
using CulinarySite.Common.Exceptions;
using CulinarySite.Common.Pagination;
using System.Linq.Expressions;
using System;

namespace CulinarySite.Bll.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IReadOnlyGenericRepository<Recipe> _recipeReadOnlyRepository;
        private readonly IWriteGenericRepository<Recipe> _recipeWriteRepository;
        private readonly IMapper _mapper;

        private readonly Dictionary<string, Expression<Func<Recipe, object>>> _orderMappings = new()
        {
            ["name"] = r => r.Name,
            ["servingsNumber"] = r => r.ServingsNumber,
            ["cookingTime"] = r => r.CookingTime,
            ["difficultyLevel"] = r => r.DifficultyLevel,
            ["dishCategory"] = r => r.Dish.Category,
            ["authorName"] = r => r.Author.Name,
            ["bookName"] = r => r.Book.Name,
        };

        private readonly List<Func<string, Expression<Func<Recipe, bool>>>> _filterMappings = new()
        {
            filter => r => r.Name.Contains(filter),
            filter => r => r.ServingsNumber.ToString().Contains(filter),
            filter => r => r.CookingTime.ToString().Contains(filter),
            filter => r => r.DifficultyLevel.Contains(filter),
            filter => r => r.Dish.Category.Contains(filter),
            filter => r => r.Author.Name.Contains(filter),
            filter => r => r.Book.Name.Contains(filter),

        };
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
            var recipeNames = _recipeReadOnlyRepository.GetItemList().Select(x => x.Name);

            if (recipeNames.Contains(createRecipeDto.Name))
            {
                throw new ValidationException($"The recipe with name:{createRecipeDto.Name} already exists.");
            }

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

        public IEnumerable<RecipeListDto> GetRecipeDetailList(bool withRelated)
        {
            IEnumerable<Recipe> recipes;
            IEnumerable<RecipeListDto> recipeListDtos;

            if (withRelated)
            {
                recipes = _recipeReadOnlyRepository.GetItemListWithInclude(
                    x => x.Dish,
                    x => x.Author,
                    x => x.Book,
                    x => x.Ingredients,
                    x => x.OrganicMatters,
                    x => x.CookingStages                    
                    );
                recipeListDtos = recipes.Select(x => _mapper.Map<RecipeListDto>(x));

                return recipeListDtos;
            }

            recipes = _recipeReadOnlyRepository.GetItemList();
            recipeListDtos = recipes.Select(x => _mapper.Map<RecipeListDto>(x));

            return recipeListDtos;
        }

        public IEnumerable<RecipeDto> GetRecipeList()
        {
            IEnumerable<Recipe> recipes = _recipeReadOnlyRepository.GetItemList();
            var recipeDtos = recipes.Select(x => _mapper.Map<RecipeDto>(x));

            return recipeDtos;
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
                    x => x.CookingStages                    
                   );

                recipeDetailDto = _mapper.Map<RecipeDetailDto>(recipe);

                return recipeDetailDto;
            }

            recipe = _recipeReadOnlyRepository.GetItem(id);

            recipeDetailDto = _mapper.Map<RecipeDetailDto>(recipe);

            return recipeDetailDto;
        }

        public PagedList<RecipeListDto> GetPaginatedRecipes(PagingParameters pagingParameters)
        {
            var query = _recipeReadOnlyRepository.GetItemListQueryableWithInclude(
                x => x.Dish,
                x => x.Author,
                x => x.Book
                );
            var result = _recipeReadOnlyRepository.GetPagedItems(query, pagingParameters, _orderMappings, _filterMappings);

            return new PagedList<RecipeListDto>(result.Items.Select(x => _mapper.Map<RecipeListDto>(x)), result.TotalCount);
        }
    }
}

