using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Tag;
using CulinarySite.Common.Dtos.Tag;
using CulinarySite.Bll.Interfaces;

namespace CulinaryApi.Controllers
{
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<TagListModel> GetTagList(bool withRelated)
        {
            IEnumerable<TagListDto> tagListDtos = _tagService.GetTagList(withRelated);
            var tagListModels = new List<TagListModel>();

            foreach (var tagListDto in tagListDtos)
            {
                tagListModels.Add(_mapper.Map<TagListModel>(tagListDto));
            }

            return tagListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public TagDetailModel GetTag(int id, bool withRelated)
        {
            TagDetailDto tagDetailDto = _tagService.GetTag(id, withRelated);
            TagDetailModel tagDetailModel = _mapper.Map<TagDetailModel>(tagDetailDto);

            return tagDetailModel;
        }

        [HttpPost]
        public void CreateTag(CreateTagModel createTagModel)
        {
            CreateTagDto createTagDto = _mapper.Map<CreateTagDto>(createTagModel);
            _tagService.CreateTag(createTagDto);
        }

        [HttpPut]
        public void UpdateTag(UpdateTagModel updateTagModel)
        {
            UpdateTagDto updateTagDto = _mapper.Map<UpdateTagDto>(updateTagModel);
            _tagService.UpdateTag(updateTagDto);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id)
        {
            _tagService.DeleteTag(id);
        }
    }
}
