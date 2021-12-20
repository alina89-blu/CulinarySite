using Database;
using Repositories;
using System.Collections.Generic;

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
        public void CreateComment(Comment comment)
        {
            this.commentWriteRepository.Create(comment);
            this.commentWriteRepository.Save();
        }
        public void DeleteComment(int id)
        {
            this.commentWriteRepository.Delete(id);
            this.commentWriteRepository.Save();
        }
        public Comment GetCommentWithInclude(int id)
        {
            return this.commentReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Restaurants,
                x => x.Subscriber);
        }
        public IEnumerable<Comment> GetCommentListWithInclude()
        {
            return this.commentReadOnlyRepository.GetItemListWithInclude(
                x => x.Restaurants,
                x => x.Subscriber);
        }
    }
}
