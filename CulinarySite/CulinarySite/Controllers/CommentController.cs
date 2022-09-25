using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Comment;
using AutoMapper;
using ServiceLayer.Dtos.Comment;

namespace CulinarySite.Controllers
{
    public class CommentController : BaseController
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
            var commentListModels = new List<CommentListModel>();

            foreach (var commentListDto in commentListDtos)
            {
                commentListModels.Add(_mapper.Map<CommentListModel>(commentListDto));
            }

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

