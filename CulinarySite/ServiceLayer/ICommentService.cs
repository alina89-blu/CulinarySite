using System.Collections.Generic;
using ServiceLayer.Dtos.Comment;

namespace ServiceLayer
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentDto createCommentDto);
        void UpdateComment(UpdateCommentDto updateCommentDto);
        void DeleteComment(int id);
        CommentDetailDto GetComment(int id, bool withRelated);
        IEnumerable<CommentListDto> GetCommentList(bool withRelated);
    }
}
