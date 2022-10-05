using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.ViewModels.Author;
using CulinarySite.Common.Dtos.Author;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class AuthorController : ApiController
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
            var authorListModels = authorListDtos.Select(x => _mapper.Map<AuthorListModel>(x));            

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


