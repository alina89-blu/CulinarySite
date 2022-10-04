using System.Collections.Generic;
using Repositories;
using AutoMapper;
using ServiceLayer.Dtos.Author;
using Database.Entities;


namespace CulinarySite.Bll.Sevices
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
            List<AuthorListDto> authorListDtos = new List<AuthorListDto>();

            foreach (var author in authors)
            {
                authorListDtos.Add(_mapper.Map<AuthorListDto>(author));
            }
            return authorListDtos;
        }

    }
}
