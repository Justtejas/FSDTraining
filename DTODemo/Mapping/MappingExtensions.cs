using DTODemo.Models;
using static DTODemo.Models.Book;

namespace DTODemo.Mapping
{
    public static class MappingExtensions
    {
        //        public static BookDTO ToDTO(this Book book)
        //        {
        //            return new BookDTO
        //            {
        //                Id = book.BookId,
        //                Author = book.Author,
        //                Price = book.Price,
        //                Title = book.Title,
        //            };
        //        }

        //        public static Book ToEntity(this BookDTO bookDTO)
        //        {
        //            return new Book
        //            {
        //                BookId = bookDTO.Id,
        //                Author = bookDTO.Author,
        //                Price = bookDTO.Price,
        //                Title = bookDTO.Title,
        //                ReleaseDate = DateTime.Now,
        //                Genre = "Comic"
        //            };
        //        }

        //        public static List<BookDTO> ToDTOList(this List<Book> books)
        //        {
        //            return books.Select(book => book.ToDTO()).ToList();
        //        }
    }
}
