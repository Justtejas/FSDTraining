using static DTODemo.Models.Book;

namespace DTODemo.Repository
{
    public interface IBookServices
    {
        public List<BookDTO> GetBooks();
        public string PostBook(BookDTO bookDTO);
    }
}
