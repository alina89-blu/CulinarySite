using Database;
using Repositories;
using System.Collections.Generic;
using ServiceLayer.ViewModels.Comment;


namespace ServiceLayer
{
    public class CommentService : ICommentService
    {
        private readonly IReadOnlyGenericRepository<Comment> commentReadOnlyRepository;
        private readonly IWriteGenericRepository<Comment> commentWriteRepository;
        public CommentService(
            IReadOnlyGenericRepository<Comment> commentReadOnlyRepository,
            IWriteGenericRepository<Comment> commentWriteRepository)
        {
            this.commentReadOnlyRepository = commentReadOnlyRepository;
            this.commentWriteRepository = commentWriteRepository;
        }

        public void CreateComment(CreateCommentModel createCommentModel)
        {
            var comment = new Comment
            {
                Content = createCommentModel.Content,
                SubscriberId = createCommentModel.SubscriberId
            };
            this.commentWriteRepository.Create(comment);
            this.commentWriteRepository.Save();
        }
        public void UpdateComment(UpdateCommentModel updateCommentModel)
        {
            var comment = new Comment
            {
                Id = updateCommentModel.CommentId,
                Content = updateCommentModel.Content,
                SubscriberId = updateCommentModel.SubscriberId
            };
            this.commentWriteRepository.Update(comment);
            this.commentWriteRepository.Save();
        }

        public void DeleteComment(int id)
        {
            this.commentWriteRepository.Delete(id);
            this.commentWriteRepository.Save();
        }

        public CommentDetailModel GetComment(int id, bool withRelated)
        {
            var comment = new Comment();
            var commentDetailModel = new CommentDetailModel();

            if (withRelated)
            {
                comment = this.commentReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Restaurants,
                x => x.Subscriber);
                commentDetailModel = new CommentDetailModel
                {
                    CommentId = comment.Id,
                    Content = comment.Content,
                    SubscriberId = comment.SubscriberId
                };
                return commentDetailModel;
            }
            comment = this.commentReadOnlyRepository.GetItem(id);
            commentDetailModel = new CommentDetailModel
            {
                CommentId = comment.Id,
                Content = comment.Content
            };
            return commentDetailModel;
        }

        public IEnumerable<CommentListModel> GetCommentList(bool withRelated)
        {
            IEnumerable<Comment> comments;
            List<CommentListModel> commentListModels = new List<CommentListModel>();
            if (withRelated)
            {
                comments = this.commentReadOnlyRepository.GetItemListWithInclude(
                x => x.Restaurants,
                x => x.Subscriber);
                foreach (var comment in comments)
                {
                    commentListModels.Add(new CommentListModel
                    {
                        CommentId = comment.Id,
                        Content = comment.Content,
                        SubscriberName = comment.Subscriber.Name
                    });
                }
                return commentListModels;
            }
            comments = this.commentReadOnlyRepository.GetItemList();
            foreach (var comment in comments)
            {
                commentListModels.Add(new CommentListModel
                {
                    CommentId = comment.Id,
                    Content = comment.Content,
                });
            }
            return commentListModels;
        }
    }
}
