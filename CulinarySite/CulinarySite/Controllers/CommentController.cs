using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Comment> GetCommentListWithInclude()
        {
            return this.commentService.GetCommentListWithInclude();
        }

        [HttpGet("{id}")]
        public Comment GetCommentWithInclude(int id)
        {
            return this.commentService.GetCommentWithInclude(id);
        }

        [HttpPost]
        public void CreateComment(Comment comment)
        {
            this.commentService.CreateComment(comment);
        }

        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            this.commentService.DeleteComment(id);
        }
    }
}

