using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.ViewModels.Book;
using CulinarySite.Common.Dtos.Book;
using System.Linq;

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
            var bookDetailListModels = bookDetailListDtos.Select(x => _mapper.Map<BookDetailListModel>(x));
            
            return bookDetailListModels;
        }

        [HttpGet("{withRelated}/sortedByYear")]
        public IEnumerable<BookDetailListModel> GetSortedBooksByYear(bool withRelated)
        {
            IEnumerable<BookDetailListDto> bookDetailListDtos = _bookService.GetSortedBooksByYear(withRelated);
            var bookDetailListModels = bookDetailListDtos.Select(x => _mapper.Map<BookDetailListModel>(x));
           
            return bookDetailListModels;
        }
    }
}

