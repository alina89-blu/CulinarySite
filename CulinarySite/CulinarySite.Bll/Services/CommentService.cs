﻿using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Comment;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
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
                x => x.Restaurants
                );

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
            IEnumerable < CommentListDto > commentListDtos;

            if (withRelated)
            {
                comments = _commentReadOnlyRepository.GetItemListWithInclude(x => x.Restaurants);

                commentListDtos = comments.Select(x => _mapper.Map<CommentListDto>(x));
                
                return commentListDtos;
            }

            comments = _commentReadOnlyRepository.GetItemList();

            commentListDtos = comments.Select(x => _mapper.Map<CommentListDto>(x));

            return commentListDtos;
        }
    }
}
