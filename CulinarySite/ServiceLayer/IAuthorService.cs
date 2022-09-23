
using System.Collections.Generic;
using ServiceLayer.ViewModels.Author;
using ServiceLayer.Dtos.Author;

namespace ServiceLayer
{
    public interface IAuthorService
    {
        void CreateAuthor(CreateAuthorDto createAuthorDto);
        void UpdateAuthor(UpdateAuthorDto updateAuthorDto);
        void DeleteAuthor(int id);
        AuthorDetailDto GetAuthor(int id, bool withRelated);        
        IEnumerable<AuthorListDto> GetAuthorList();
    }
}
