using System.Collections.Generic;
using System.Linq;
using AutoMapper;


namespace CulinarySite.Bll.Sevices
{
    public class BookService : IBookService
    {
        private readonly IReadOnlyGenericRepository<Book> _bookReadOnlyRepository;
        private readonly IWriteGenericRepository<Book> _bookWriteRepository;
        private readonly IMapper _mapper;
        public BookService(
            IReadOnlyGenericRepository<Book> bookReadOnlyRepository,
            IWriteGenericRepository<Book> bookWriteRepository,
            IMapper mapper)
        {
            _bookReadOnlyRepository = bookReadOnlyRepository;
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public void CreateBook(CreateBookDto createBookDto)
        {
            Book book = _mapper.Map<Book>(createBookDto);

            _bookWriteRepository.Create(book);
            _bookWriteRepository.Save();
        }

        public void UpdateBook(UpdateBookDto updateBookDto)
        {
            Book book = _mapper.Map<Book>(updateBookDto);

            _bookWriteRepository.Update(book);
            _bookWriteRepository.Save();
        }

        public void DeleteBook(int id)
        {
            _bookWriteRepository.Delete(id);
            _bookWriteRepository.Save();
        }

        public BookDetailDto GetBook(int id, bool withRelated)
        {
            var book = new Book();
            var bookDetailDto = new BookDetailDto();

            if (withRelated)
            {
                book = _bookReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Author);

                bookDetailDto = _mapper.Map<BookDetailDto>(book);

                return bookDetailDto;
            }
            book = _bookReadOnlyRepository.GetItem(id);

            bookDetailDto = _mapper.Map<BookDetailDto>(book);

            return bookDetailDto;
        }
        public IEnumerable<BookDetailListDto> GetBookDetailList(bool withRelated)
        {
            IEnumerable<Book> books;
            var bookDetailListDtos = new List<BookDetailListDto>();

            if (withRelated)
            {
                books = _bookReadOnlyRepository.GetItemListWithInclude(
                x => x.Author);

                foreach (var book in books)
                {
                    bookDetailListDtos.Add(_mapper.Map<BookDetailListDto>(book));
                }
                return bookDetailListDtos;
            }

            books = _bookReadOnlyRepository.GetItemList();

            foreach (var book in books)
            {
                bookDetailListDtos.Add(_mapper.Map<BookDetailListDto>(book));
            }

            return bookDetailListDtos;
        }

        public IEnumerable<BookDto> GetBookList()
        {
            IEnumerable<Book> books = _bookReadOnlyRepository.GetItemList();
            var bookDtos = new List<BookDto>();

            foreach (var book in books)
            {
                bookDtos.Add(_mapper.Map<BookDto>(book));
            }

            return bookDtos;
        }

        public IEnumerable<BookDetailListDto> GetSortedBooksByName(bool withRelated)
        {
            List<BookDetailListDto> books = GetBookDetailList(withRelated).ToList();
            books.Sort(new BookNameComparer());
            return books;
        }

        public IEnumerable<BookDetailListDto> GetSortedBooksByYear(bool withRelated)
        {
            List<BookDetailListDto> books = GetBookDetailList(withRelated).ToList();
            books.Sort(new BookYearComparer());
            return books;
        }
        
    }
}
