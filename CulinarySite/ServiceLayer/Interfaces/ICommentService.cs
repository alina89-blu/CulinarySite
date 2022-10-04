using CulinarySite.Common.Dtos.Comment;
using System.Collections.Generic;

namespace CulinarySite.Bll.Interfaces
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
