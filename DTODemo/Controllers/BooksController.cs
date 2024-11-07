using DTODemo.Repository;
using Microsoft.AspNetCore.Mvc;
using static DTODemo.Models.Book;

namespace DTODemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks()
        {
            var books = _bookServices.GetBooks();
            return books;
        }
        [HttpPost]
        public IActionResult PostBook(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Invalid Book Data");
            }
            var status = _bookServices.PostBook(bookDTO);
            if (status == null)
            {
                return BadRequest("Invalid Book Data");
            }
            return Ok(status);
        }
    }
}
