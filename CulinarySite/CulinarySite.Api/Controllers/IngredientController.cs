using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Ingredient;
using CulinarySite.Common.Dtos.Ingredient;
using CulinarySite.Bll.Interfaces;
using System.Linq;

namespace CulinarySite.Api.Controllers
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
            var ingredientListModels = ingredientListDtos.Select(x => _mapper.Map<IngredientListModel>(x));           

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

