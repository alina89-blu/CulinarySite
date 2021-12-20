using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class DishController:BaseController
    {
        private readonly IDishService dishService;
        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }
        [HttpGet]
        public IEnumerable<Dish> GetDishListWithInclude()
        {
            return this.dishService.GetDishListWithInclude();
        }

        [HttpGet("{id}")]
        public Dish GetDishWithInclude(int id)
        {
            return this.dishService.GetDishWithInclude(id);
        }

        [HttpPost]
        public void CreateDish(Dish dish)
        {
            this.dishService.CreateDish(dish);
        }

        [HttpPut]
        public void UpdateDish(Dish dish)
        {
            this.dishService.UpdateDish(dish);
        }

        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            this.dishService.DeleteDish(id);
        }
    }
}
