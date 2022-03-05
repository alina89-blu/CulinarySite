using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.RecipeOrganicMatter;

namespace ServiceLayer
{
    public class RecipeOrganicMatterService : IRecipeOrganicMatterService
    {
        private readonly IReadOnlyGenericRepository<RecipeOrganicMatter> recipeOrganicMatterReadOnlyRepository;
        private readonly IWriteGenericRepository<RecipeOrganicMatter> recipeOrganicMatterWriteRepository;
        public RecipeOrganicMatterService(
            IReadOnlyGenericRepository<RecipeOrganicMatter> recipeOrganicMatterReadOnlyRepository,
            IWriteGenericRepository<RecipeOrganicMatter> recipeOrganicMatterWriteRepository)
        {
            this.recipeOrganicMatterReadOnlyRepository = recipeOrganicMatterReadOnlyRepository;
            this.recipeOrganicMatterWriteRepository = recipeOrganicMatterWriteRepository;
        }
        public void CreateRecipeOrganicMatter(CreateRecipeOrganicMatterModel createRecipeOrganicMatterModel)
        {
            var recipeOrganicMatter = new RecipeOrganicMatter
            {
                OrganicMatterId = createRecipeOrganicMatterModel.OrganicMatterId,
                Unit = createRecipeOrganicMatterModel.Unit,
                Quantity = createRecipeOrganicMatterModel.Quantity,
            };
            this.recipeOrganicMatterWriteRepository.Create(recipeOrganicMatter);
            this.recipeOrganicMatterWriteRepository.Save();
        }

        public void UpdateRecipeOrganicMatter(UpdateRecipeOrganicMatterModel updateRecipeOrganicMatterModel)
        {
            var recipeOrganicMatter = new RecipeOrganicMatter
            {
                Id = updateRecipeOrganicMatterModel.RecipeOrganicMatterId,
                OrganicMatterId = updateRecipeOrganicMatterModel.OrganicMatterId,
                Unit = updateRecipeOrganicMatterModel.Unit,
                Quantity = updateRecipeOrganicMatterModel.Quantity,
            };
            this.recipeOrganicMatterWriteRepository.Update(recipeOrganicMatter);
            this.recipeOrganicMatterWriteRepository.Save();
        }

        public void DeleteRecipeOrganicMatter(int id)
        {
            this.recipeOrganicMatterWriteRepository.Delete(id);
            this.recipeOrganicMatterWriteRepository.Save();
        }

        public IEnumerable<RecipeOrganicMatterListModel> GetRecipeOrganicMatterList(bool withRelated)
        {
            IEnumerable<RecipeOrganicMatter> recipeOrganicMatters;
            List<RecipeOrganicMatterListModel> recipeOrganicMatterListModels = new List<RecipeOrganicMatterListModel>();
            if (withRelated)
            {
                recipeOrganicMatters = this.recipeOrganicMatterReadOnlyRepository.GetItemListWithInclude(
                    x => x.OrganicMatter,
                    x => x.Recipes);
                foreach (var recipeOrganicMatter in recipeOrganicMatters)
                {
                    recipeOrganicMatterListModels.Add(new RecipeOrganicMatterListModel
                    {
                        RecipeOrganicMatterId = recipeOrganicMatter.Id,
                        OrganicMatterName = recipeOrganicMatter.OrganicMatter.Name,
                        Unit = recipeOrganicMatter.Unit,
                        Quantity = recipeOrganicMatter.Quantity,
                    });
                }
                return recipeOrganicMatterListModels;
            }
            recipeOrganicMatters = this.recipeOrganicMatterReadOnlyRepository.GetItemList();
            foreach (var recipeOrganicMatter in recipeOrganicMatters)
            {
                recipeOrganicMatterListModels.Add(new RecipeOrganicMatterListModel
                {
                    RecipeOrganicMatterId = recipeOrganicMatter.Id,
                    Unit = recipeOrganicMatter.Unit,
                    Quantity = recipeOrganicMatter.Quantity
                });
            }
            return recipeOrganicMatterListModels;
        }

        public RecipeOrganicMatterDetailModel GetRecipeOrganicMatter(int id, bool withRelated)
        {
            RecipeOrganicMatter recipeOrganicMatter = new RecipeOrganicMatter();
            RecipeOrganicMatterDetailModel recipeOrganicMatterDetailModel = new RecipeOrganicMatterDetailModel();

            if (withRelated)
            {
                recipeOrganicMatter = this.recipeOrganicMatterReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.OrganicMatter,
                    x => x.Recipes);
                recipeOrganicMatterDetailModel = new RecipeOrganicMatterDetailModel
                {
                    RecipeOrganicMatterId = recipeOrganicMatter.Id,
                    OrganicMatterId = recipeOrganicMatter.OrganicMatterId,
                    Unit = recipeOrganicMatter.Unit,
                    Quantity = recipeOrganicMatter.Quantity,
                };
                return recipeOrganicMatterDetailModel;
            }
            recipeOrganicMatter = this.recipeOrganicMatterReadOnlyRepository.GetItem(id);
            recipeOrganicMatterDetailModel = new RecipeOrganicMatterDetailModel
            {
                RecipeOrganicMatterId = recipeOrganicMatter.Id,
                Unit = recipeOrganicMatter.Unit,
                Quantity = recipeOrganicMatter.Quantity
            };
            return recipeOrganicMatterDetailModel;
        }
    }
}

