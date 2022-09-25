using Database;
using Repositories;
using System.Collections.Generic;
using AutoMapper;
using ServiceLayer.Dtos.Comment;

namespace ServiceLayer
{
    public class CommentService : ICommentService
    {
        private readonly IReadOnlyGenericRepository<Comment> _commentReadOnlyRepository;
        private readonly IWriteGenericRepository<Comment> _commentWriteRepository;
        private readonly IMapper _mapper;
        public CommentService(
            IReadOnlyGenericRepository<Comment> commentReadOnlyRepository,
            IWriteGenericRepository<Comment> commentWriteRepository,
            IMapper mapper)
        {
            _commentReadOnlyRepository = commentReadOnlyRepository;
            _commentWriteRepository = commentWriteRepository;
            _mapper = mapper;
        }

        public void CreateComment(CreateCommentDto createCommentDto)
        {
            Comment comment = _mapper.Map<Comment>(createCommentDto);

            _commentWriteRepository.Create(comment);
            _commentWriteRepository.Save();
        }
        public void UpdateComment(UpdateCommentDto updateCommentDto)
        {
            Comment comment = _mapper.Map<Comment>(updateCommentDto);

            _commentWriteRepository.Update(comment);
            _commentWriteRepository.Save();
        }

        public void DeleteComment(int id)
        {
            _commentWriteRepository.Delete(id);
            _commentWriteRepository.Save();
        }

        public CommentDetailDto GetComment(int id, bool withRelated)
        {
            var comment = new Comment();
            var commentDetailDto = new CommentDetailDto();

            if (withRelated)
            {
                comment = _commentReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Restaurants,
                x => x.Subscriber);

                commentDetailDto = _mapper.Map<CommentDetailDto>(comment);

                return commentDetailDto;
            }

            comment = _commentReadOnlyRepository.GetItem(id);

            commentDetailDto = _mapper.Map<CommentDetailDto>(comment);

            return commentDetailDto;
        }

        public IEnumerable<CommentListDto> GetCommentList(bool withRelated)
        {
            IEnumerable<Comment> comments;
            var commentListDtos = new List<CommentListDto>();

            if (withRelated)
            {
                comments = _commentReadOnlyRepository.GetItemListWithInclude(
                x => x.Restaurants,
                x => x.Subscriber);

                foreach (var comment in comments)
                {
                    commentListDtos.Add(_mapper.Map<CommentListDto>(comment));
                }

                return commentListDtos;
            }

            comments = _commentReadOnlyRepository.GetItemList();

            foreach (var comment in comments)
            {
                commentListDtos.Add(_mapper.Map<CommentListDto>(comment));
            }

            return commentListDtos;
        }
    }
}
