using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Author;
using AutoMapper;
using ServiceLayer.Dtos.Author;

namespace CulinarySite.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AuthorListModel> GetAuthorList()
        {
            IEnumerable<AuthorListDto> authorListDtos = _authorService.GetAuthorList();
            List<AuthorListModel> authorListModels = new List<AuthorListModel>();

            foreach (var authorListDto in authorListDtos)
            {
                authorListModels.Add(_mapper.Map<AuthorListModel>(authorListDto));
            }

            return authorListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public AuthorDetailModel GetAuthor(int id, bool withRelated)
        {
            AuthorDetailDto authorDetailDto = _authorService.GetAuthor(id, withRelated);
            AuthorDetailModel authorDetailModel = _mapper.Map<AuthorDetailModel>(authorDetailDto);
            return authorDetailModel;
        }

        [HttpPost]
        public void CreateAuthor(CreateAuthorModel createAuthorModel)
        {
            var сreateAuthorDto = _mapper.Map<CreateAuthorDto>(createAuthorModel);
            _authorService.CreateAuthor(сreateAuthorDto);
        }

        [HttpPut]
        public void UpdateAuthor(UpdateAuthorModel updateAuthorModel)
        {
            var updateAuthorDto = _mapper.Map<UpdateAuthorDto>(updateAuthorModel);
            _authorService.UpdateAuthor(updateAuthorDto);
        }

        [HttpDelete("{id}")]
        public void DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
        }
    }
}


