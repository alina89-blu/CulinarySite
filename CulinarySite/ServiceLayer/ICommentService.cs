using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ICommentService
    {
        void CreateComment(Comment Comment);
        void DeleteComment(int id);
        Comment GetCommentWithInclude(int id);
        IEnumerable<Comment> GetCommentListWithInclude();
    }
}
