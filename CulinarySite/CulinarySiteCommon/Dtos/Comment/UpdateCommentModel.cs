

namespace ServiceLayer.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int SubscriberId { get; set; }
    }
}
