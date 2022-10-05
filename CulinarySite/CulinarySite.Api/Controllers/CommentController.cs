using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.ViewModels.Comment;
using CulinarySite.Common.Dtos.Comment;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CommentListModel> GetCommentList(bool withRelated)
        {
            IEnumerable<CommentListDto> commentListDtos = _commentService.GetCommentList(withRelated);
            var commentListModels = commentListDtos.Select(x => _mapper.Map<CommentListModel>(x));           

            return commentListModels;
        }

        [HttpGet("{id}")]
        public CommentDetailModel GetComment(int id, bool withRelated)
        {
            CommentDetailDto commentDetailDto = _commentService.GetComment(id, withRelated);
            CommentDetailModel commentDetailModel = _mapper.Map<CommentDetailModel>(commentDetailDto);

            return commentDetailModel;
        }

        [HttpPost]
        public void CreateComment(CreateCommentModel createCommentModel)
        {
            CreateCommentDto createCommentDto = _mapper.Map<CreateCommentDto>(createCommentModel);
            _commentService.CreateComment(createCommentDto);
        }

        [HttpPut]
        public void UpdateComment(UpdateCommentModel updateCommentModel)
        {
            UpdateCommentDto updateCommentDto = _mapper.Map<UpdateCommentDto>(updateCommentModel);
            _commentService.UpdateComment(updateCommentDto);
        }

        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
        }
    }
}

