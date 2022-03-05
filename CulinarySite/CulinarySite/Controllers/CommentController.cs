using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Comment;

namespace CulinarySite.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<CommentListModel> GetCommentList(bool withRelated)
        {
            return this.commentService.GetCommentList(withRelated);
        }

        [HttpGet("{id}")]
        public CommentDetailModel GetComment(int id, bool withRelated)
        {
            return this.commentService.GetComment(id,withRelated);
        }

        [HttpPost]
        public void CreateComment(CreateCommentModel createCommentModel)
        {
            this.commentService.CreateComment(createCommentModel);
        }

        [HttpPut]
        public void UpdateComment(UpdateCommentModel updateCommentModel)
        {
            this.commentService.UpdateComment(updateCommentModel);
        }

        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            this.commentService.DeleteComment(id);
        }
    }
}

