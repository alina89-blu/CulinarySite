using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Dish;

namespace CulinarySite.Controllers
{
    public class DishController:BaseController
    {
        private readonly IDishService dishService;
        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<DishListModel> GetDishList(bool withRelated)
        {
            return this.dishService.GetDishList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public DishDetailModel GetDish(int id, bool withRelated)
        {
            return this.dishService.GetDish(id,withRelated);
        }

        [HttpPost]
        public void CreateDish(CreateDishModel createDishModel)
        {
            this.dishService.CreateDish(createDishModel);
        }

        [HttpPut]
        public void UpdateDish(UpdateDishModel updateDishModel)
        {
            this.dishService.UpdateDish(updateDishModel);
        }

        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            this.dishService.DeleteDish(id);
        }
    }
}
