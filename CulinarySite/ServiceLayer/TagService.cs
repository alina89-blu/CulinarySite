using Database;
using Repositories;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class TagService : ITagService
    {
        private readonly IReadOnlyGenericRepository<Tag> tagReadOnlyRepository;
        private readonly IWriteGenericRepository<Tag> tagWriteRepository;
        public TagService(
            IReadOnlyGenericRepository<Tag> tagReadOnlyRepository,
            IWriteGenericRepository<Tag> tagWriteRepository)
        {
            this.tagReadOnlyRepository = tagReadOnlyRepository;
            this.tagWriteRepository = tagWriteRepository;
        }

        public void CreateTag(Tag tag)
        {
            this.tagWriteRepository.Create(tag);
            this.tagWriteRepository.Save();
        }

        public void UpdateTag(Tag tag)
        {
            this.tagWriteRepository.Update(tag);
            this.tagWriteRepository.Save();
        }

        public void DeleteTag(int id)
        {
            this.tagWriteRepository.Delete(id);
            this.tagWriteRepository.Save();
        }

        public IEnumerable<Tag> GetTagListWithInclude()
        {
            return this.tagReadOnlyRepository.GetItemListWithInclude(
                x => x.Recipes,
                x => x.Episodes);
        }

        public Tag GetTagWithInclude(int id)
        {
            return this.tagReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipes,
                x => x.Episodes);
        }
    }
}
