using Database;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Author;

namespace ServiceLayer
{
    public interface IAuthorService
    {
        void CreateAuthor(CreateAuthorModel createAuthorModel);
        void UpdateAuthor(UpdateAuthorModel updateAuthorModel);
        void DeleteAuthor(int id);
        AuthorDetailModel GetAuthor(int id, bool withRelated);
        IEnumerable<AuthorDetailListModel> GetAuthorDetailList(bool withRelated);
        IEnumerable<AuthorModel> GetAuthorList();
    }
}
