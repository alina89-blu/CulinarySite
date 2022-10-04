using CulinarySite.Common.Dtos.Author;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
