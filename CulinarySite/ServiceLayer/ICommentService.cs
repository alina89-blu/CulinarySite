using System.Collections.Generic;
using ServiceLayer.ViewModels.Comment;

namespace ServiceLayer
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentModel createCommentModel);
        void UpdateComment(UpdateCommentModel updateCommentModel);
        void DeleteComment(int id);
        CommentDetailModel GetComment(int id, bool withRelated);
        IEnumerable<CommentListModel> GetCommentList(bool withRelated);
    }
}
