using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Recipe;
using CulinarySite.Common.Dtos.Recipe;
using CulinarySite.Bll.Interfaces;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<RecipeListModel> GetRecipeDetailList(bool withRelated)
        {
            IEnumerable<RecipeListDto> recipeListDtos = _recipeService.GetRecipeDetailList(withRelated);
            var recipeListModels = recipeListDtos.Select(x => _mapper.Map<RecipeListModel>(x));           

            return recipeListModels;
        }

        [HttpGet]
        public IEnumerable<RecipeModel> GetRecipeList()
        {
            IEnumerable<RecipeDto> recipeDtos = _recipeService.GetRecipeList();
            var recipeModels = recipeDtos.Select(x => _mapper.Map<RecipeModel>(x));

            return recipeModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public RecipeDetailModel GetRecipe(int id, bool withRelated)
        {
            RecipeDetailDto recipeDetailDto = _recipeService.GetRecipe(id, withRelated);
            RecipeDetailModel recipeDetailModel = _mapper.Map<RecipeDetailModel>(recipeDetailDto);

            return recipeDetailModel;
        }

        [HttpPost]
        public void CreateRecipe(CreateRecipeModel createRecipeModel)
        {
            CreateRecipeDto createRecipeDto = _mapper.Map<CreateRecipeDto>(createRecipeModel);
            _recipeService.CreateRecipe(createRecipeDto);
        }

        [HttpPut]
        public void UpdateRecipe(UpdateRecipeModel updateRecipeModel)
        {
            UpdateRecipeDto updateRecipeDto = _mapper.Map<UpdateRecipeDto>(updateRecipeModel);
            _recipeService.UpdateRecipe(updateRecipeDto);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            _recipeService.DeleteRecipe(id);
        }
    }
}
