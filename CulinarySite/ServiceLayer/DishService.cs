using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Database;

namespace ServiceLayer
{
  public  class DishService:IDishService
    {
        private readonly IReadOnlyGenericRepository<Dish> dishReadOnlyRepository;
        private readonly IWriteGenericRepository<Dish> dishWriteRepository;
        public DishService(IReadOnlyGenericRepository<Dish> dishReadOnlyRepository, 
            IWriteGenericRepository<Dish> dishWriteRepository)
        {
            this.dishReadOnlyRepository = dishReadOnlyRepository;
            this.dishWriteRepository = dishWriteRepository;
        }
       public void CreateDish(Dish dish)
        {
            this.dishWriteRepository.Create(dish);
            this.dishWriteRepository.Save();
        }
        public void UpdateDish(Dish dish)
        {
            this.dishWriteRepository.Update(dish);
            this.dishWriteRepository.Save();
        }
        public void DeleteDish(int id)
        {
            this.dishWriteRepository.Delete(id);
            this.dishWriteRepository.Save();
        }
        public Dish GetDishWithInclude(int id)
        {
            return this.dishReadOnlyRepository.GetItemWithInclude(x=>x.Id==id, x => x.Recipes, x => x.Image);
        }
        public IEnumerable<Dish> GetDishListWithInclude()
        {
            return this.dishReadOnlyRepository.GetItemListWithInclude(x=>x.Recipes,x=>x.Image);
        }

    }
}

