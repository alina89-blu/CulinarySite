using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.ViewModels.Book;
using CulinarySite.Common.Dtos.Book;
using System.Linq;
using CulinarySite.Common.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace CulinarySite.Api.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<BookDetailListModel> GetBookDetailList(bool withRelated)
        {
            IEnumerable<BookDetailListDto> bookDetailListDtos = _bookService.GetBookDetailList(withRelated);
            var bookDetailListModels = bookDetailListDtos.Select(x => _mapper.Map<BookDetailListModel>(x));

            return bookDetailListModels;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBookList()
        {
            IEnumerable<BookDto> bookDtos = _bookService.GetBookList();
            var bookModels = bookDtos.Select(x => _mapper.Map<BookModel>(x));

            return bookModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public BookDetailModel GetBook(int id, bool withRelated)
        {
            BookDetailDto bookDetailDto = _bookService.GetBook(id, withRelated);
            BookDetailModel bookDetailModel = _mapper.Map<BookDetailModel>(bookDetailDto);

            return bookDetailModel;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public void CreateBook(CreateBookModel createBookModel)
        {
            CreateBookDto createBookDto = _mapper.Map<CreateBookDto>(createBookModel);
            _bookService.CreateBook(createBookDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public void UpdateBook(UpdateBookModel updateBookModel)
        {
            UpdateBookDto updateBookDto = _mapper.Map<UpdateBookDto>(updateBookModel);
            _bookService.UpdateBook(updateBookDto);
        }

        [Authorize(Roles = "admin")]      
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        [HttpGet("paged")]
        public PagedList<BookDetailListModel> GetPaginatedBooks([FromQuery] PagingParameters pagingParameters)
        {
            PagedList<BookDetailListDto> result = _bookService.GetPaginatedBooks(pagingParameters);

            var bookDetailListModels = result.Items.Select(x => _mapper.Map<BookDetailListModel>(x));

            return new PagedList<BookDetailListModel>(bookDetailListModels, result.TotalCount);
        }
    }
}

