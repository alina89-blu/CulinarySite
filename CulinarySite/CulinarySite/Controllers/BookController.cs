using ServiceLayer;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Book;
using AutoMapper;
using ServiceLayer.Dtos.Book;

namespace CulinarySite.Controllers
{
    public class BookController : BaseController
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
            var bookDetailListModels = new List<BookDetailListModel>();

            foreach (var bookDetailListDto in bookDetailListDtos)
            {
                bookDetailListModels.Add(_mapper.Map<BookDetailListModel>(bookDetailListDto));
            }

            return bookDetailListModels;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBookList()
        {
            IEnumerable<BookDto> bookDtos = _bookService.GetBookList();
            var bookModels = new List<BookModel>();

            foreach (var bookDto in bookDtos)
            {
                bookModels.Add(_mapper.Map<BookModel>(bookDto));
            }

            return bookModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public BookDetailModel GetBook(int id, bool withRelated)
        {
            BookDetailDto bookDetailDto = _bookService.GetBook(id, withRelated);
            BookDetailModel bookDetailModel = _mapper.Map<BookDetailModel>(bookDetailDto);

            return bookDetailModel;
        }

        [HttpPost]
        public void CreateBook(CreateBookModel createBookModel)
        {
            CreateBookDto createBookDto = _mapper.Map<CreateBookDto>(createBookModel);
            _bookService.CreateBook(createBookDto);
        }

        [HttpPut]
        public void UpdateBook(UpdateBookModel updateBookModel)
        {
            UpdateBookDto updateBookDto = _mapper.Map<UpdateBookDto>(updateBookModel);
            _bookService.UpdateBook(updateBookDto);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        [HttpGet("{withRelated}/sortedByName")]
        public IEnumerable<BookDetailListModel> GetSortedBooksByName(bool withRelated)
        {
            IEnumerable<BookDetailListDto> bookDetailListDtos = _bookService.GetSortedBooksByName(withRelated);
            var bookDetailListModels = new List<BookDetailListModel>();

            foreach (var bookDetailListDto in bookDetailListDtos)
            {
                bookDetailListModels.Add(_mapper.Map<BookDetailListModel>(bookDetailListDto));
            }
            return bookDetailListModels;
        }

        [HttpGet("{withRelated}/sortedByYear")]
        public IEnumerable<BookDetailListModel> GetSortedBooksByYear(bool withRelated)
        {
            IEnumerable<BookDetailListDto> bookDetailListDtos = _bookService.GetSortedBooksByYear(withRelated);
            var bookDetailListModels = new List<BookDetailListModel>();

            foreach (var bookDetailListDto in bookDetailListDtos)
            {
                bookDetailListModels.Add(_mapper.Map<BookDetailListModel>(bookDetailListDto));
            }
            return bookDetailListModels;
        }
    }
}

