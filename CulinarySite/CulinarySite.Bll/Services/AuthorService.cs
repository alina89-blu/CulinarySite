﻿using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Author;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;
using CulinarySite.Common.Exceptions;

namespace CulinarySite.Bll.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IReadOnlyGenericRepository<Author> _authorReadOnlyRepository;
        private readonly IWriteGenericRepository<Author> _authorWriteRepository;
        private readonly IMapper _mapper;
        public AuthorService(
            IReadOnlyGenericRepository<Author> authorReadOnlyRepository,
            IWriteGenericRepository<Author> authorWriteRepository,
            IMapper mapper)
        {
            _authorReadOnlyRepository = authorReadOnlyRepository;
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
        }

        public void CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var authorNames = _authorReadOnlyRepository.GetItemList().Select(x => x.Name);

            if (authorNames.Contains(createAuthorDto.Name))
            {
                throw new ValidationException($"The author with name:{createAuthorDto.Name} already exists.");
            }

            Author author = _mapper.Map<Author>(createAuthorDto);

            _authorWriteRepository.Create(author);
            _authorWriteRepository.Save();
        }

        public void UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {           
            Author author = _mapper.Map<Author>(updateAuthorDto);

            _authorWriteRepository.Update(author);
            _authorWriteRepository.Save();
        }

        public void DeleteAuthor(int id)
        {
            _authorWriteRepository.Delete(id);
            _authorWriteRepository.Save();
        }

        public AuthorDetailDto GetAuthor(int id, bool withRelated)
        {
            var author = new Author();
            var authorDetailDto = new AuthorDetailDto();

            if (withRelated)
            {
                author = _authorReadOnlyRepository.GetItemWithInclude(
                       x => x.Id == id,
                       x => x.Books,
                       x => x.Recipes);

                authorDetailDto = _mapper.Map<AuthorDetailDto>(author);

                return authorDetailDto;
            }

            author = _authorReadOnlyRepository.GetItem(id);

            authorDetailDto = _mapper.Map<AuthorDetailDto>(author);

            return authorDetailDto;
        }

        public IEnumerable<AuthorListDto> GetAuthorList()
        {
            IEnumerable<Author> authors = _authorReadOnlyRepository.GetItemList();
            var authorListDtos = authors.Select(x => _mapper.Map<AuthorListDto>(x));
           
            return authorListDtos;
        }

    }
}
