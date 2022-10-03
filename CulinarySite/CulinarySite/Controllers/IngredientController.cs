using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Ingredient;
using AutoMapper;
using ServiceLayer.Dtos.Ingredient;

namespace CulinaryApi.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;
        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<IngredientListModel> GetIngredientList()
        {
            IEnumerable<IngredientListDto> ingredientListDtos = _ingredientService.GetIngredientList();
            var ingredientListModels = new List<IngredientListModel>();

            foreach (var ingredientListDto in ingredientListDtos)
            {
                ingredientListModels.Add(_mapper.Map<IngredientListModel>(ingredientListDto));
            }

            return ingredientListModels;
        }

        [HttpGet("{id}")]
        public IngredientDetailModel GetIngredient(int id)
        {
            IngredientDetailDto ingredientDetailDto = _ingredientService.GetIngredient(id);
            IngredientDetailModel ingredientDetailModel = _mapper.Map<IngredientDetailModel>(ingredientDetailDto);

            return ingredientDetailModel;
        }

        [HttpPost]
        public void CreateIngredient(CreateIngredientModel createIngredientModel)
        {
            CreateIngredientDto createIngredientDto = _mapper.Map<CreateIngredientDto>(createIngredientModel);
            _ingredientService.CreateIngredient(createIngredientDto);
        }

        [HttpPut]
        public void UpdateIngredient(UpdateIngredientModel updateIngredientModel)
        {
            UpdateIngredientDto updateIngredientDto = _mapper.Map<UpdateIngredientDto>(updateIngredientModel);
            _ingredientService.UpdateIngredient(updateIngredientDto);
        }

        [HttpDelete("{id}")]
        public void DeleteIngredient(int id)
        {
            _ingredientService.DeleteIngredient(id);
        }
    }
}

