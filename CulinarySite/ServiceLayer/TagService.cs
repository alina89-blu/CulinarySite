using Repositories;
using System.Collections.Generic;
using AutoMapper;
using ServiceLayer.Dtos.Tag;
using Database.Entities;

namespace ServiceLayer
{
    public class TagService : ITagService
    {
        private readonly IReadOnlyGenericRepository<Tag> _tagReadOnlyRepository;
        private readonly IWriteGenericRepository<Tag> _tagWriteRepository;
        private readonly IMapper _mapper;
        public TagService(
            IReadOnlyGenericRepository<Tag> tagReadOnlyRepository,
            IWriteGenericRepository<Tag> tagWriteRepository,
            IMapper mapper)
        {
            _tagReadOnlyRepository = tagReadOnlyRepository;
            _tagWriteRepository = tagWriteRepository;
            _mapper = mapper;
        }

        public void CreateTag(CreateTagDto createTagDto)
        {
            Tag tag = _mapper.Map<Tag>(createTagDto);

            _tagWriteRepository.Create(tag);
            _tagWriteRepository.Save();
        }

        public void UpdateTag(UpdateTagDto updateTagDto)
        {
            Tag tag = _mapper.Map<Tag>(updateTagDto);

            _tagWriteRepository.Update(tag);
            _tagWriteRepository.Save();
        }

        public void DeleteTag(int id)
        {
            _tagWriteRepository.Delete(id);
            _tagWriteRepository.Save();
        }

        public IEnumerable<TagListDto> GetTagList(bool withRelated)
        {
            IEnumerable<Tag> tags;
            var tagListDtos = new List<TagListDto>();

            if (withRelated)
            {
                tags = _tagReadOnlyRepository.GetItemListWithInclude(
                                x => x.Recipes,
                                x => x.Episodes);
                foreach (var tag in tags)
                {
                    tagListDtos.Add(_mapper.Map<TagListDto>(tag));
                }

                return tagListDtos;
            }

            tags = _tagReadOnlyRepository.GetItemList();

            foreach (var tag in tags)
            {
                tagListDtos.Add(_mapper.Map<TagListDto>(tag));
            }

            return tagListDtos;
        }

        public TagDetailDto GetTag(int id, bool withRelated)
        {
            var tag = new Tag();
            var tagDetailDto = new TagDetailDto();

            if (withRelated)
            {
                tag = _tagReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Recipes,
                x => x.Episodes);

                tagDetailDto = _mapper.Map<TagDetailDto>(tag);

                return tagDetailDto;
            }

            tag = _tagReadOnlyRepository.GetItem(id);

            tagDetailDto = _mapper.Map<TagDetailDto>(tag);

            return tagDetailDto;
        }
    }
}
