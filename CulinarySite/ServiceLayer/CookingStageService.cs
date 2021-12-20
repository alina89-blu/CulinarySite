using System.Collections.Generic;
using Repositories;
using Database;

namespace ServiceLayer
{
    public class CookingStageService : ICookingStageService
    {
        private readonly IReadOnlyGenericRepository<CookingStage> cookingStageReadOnlyRepository;
        private readonly IWriteGenericRepository<CookingStage> cookingStageWriteRepository;
        public CookingStageService(IReadOnlyGenericRepository<CookingStage> cookingStageReadOnlyRepository,
            IWriteGenericRepository<CookingStage> cookingStageWriteRepository)
        {
            this.cookingStageReadOnlyRepository = cookingStageReadOnlyRepository;
            this.cookingStageWriteRepository = cookingStageWriteRepository;
        }
        public void CreateCookingStage(CookingStage cookingStage)
        {
            this.cookingStageWriteRepository.Create(cookingStage);
            this.cookingStageWriteRepository.Save();

        }
        public void UpdateCookingStage(CookingStage cookingStage)
        {
            this.cookingStageWriteRepository.Update(cookingStage);
            this.cookingStageWriteRepository.Save();
        }
        public void DeleteCookingStage(int id)
        {
            this.cookingStageWriteRepository.Delete(id);
            this.cookingStageWriteRepository.Save();
        }
        public IEnumerable<CookingStage> GetCookingStageListWithInclude()
        {
            return this.cookingStageReadOnlyRepository.GetItemListWithInclude(x => x.Recipe, x => x.Images);
        }
        public CookingStage GetCookingStageWithInclude(int id)
        {
            return this.cookingStageReadOnlyRepository.GetItemWithInclude(x => x.Id == id, x => x.Recipe, x => x.Images);
        }
    }
}


