using AutoMapper;
using DTODemo.Models;
using static DTODemo.Models.Book;

namespace DTODemo.Repository
{
    public class BookService : IBookServices
    {
        private readonly MyContext _myContext;
        private readonly IMapper _mapper;
        public BookService(MyContext myContext, IMapper mapper)
        {
            _myContext = myContext;
            _mapper = mapper;
        }
        public List<BookDTO> GetBooks()
        {
            List<Book> books = _myContext.Books.ToList();
            if (books == null || books.Count == 0)
            {
                return null;
            }
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;
        }

        public string PostBook(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return null;
            }
            //var book = bookDTO.ToEntity();
            var book = _mapper.Map<Book>(bookDTO);
            _myContext.Books.Add(book);
            _myContext.SaveChanges();
            return "Added Book";
        }
    }
}
