using System;
using System.Threading.Tasks;
using Bookstore.Api.BindingModels;
using Bookstore.Api.Mappers;
using Bookstore.Api.ViewModels;
using Bookstore.Data.Sql;
using Bookstore.Data.Sql.DAO;
using Bookstore.IServices.Book;
using Bookstore.Api.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Controllers
{
    
    //Kontrolery eksponują endpointy, które są dostępne z poziomu przeglądarki.
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/book")]
    public class BookController : Controller
    {
        private readonly BookstoreDbContext _context;
        private readonly IBookService _bookService;

        public BookController(BookstoreDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        [HttpGet("{bookId:min(1)}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await _bookService.GetBookByBookId(bookId);
            if (book != null)
            {
                return Ok(BookToBookViewModelMapper.BookToBookViewModel(book));
            }
            
            return NotFound();
        }

        [HttpGet("title/{title}", Name = "GetBookByTitle")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var book = await _bookService.GetBookByTitle(title);
            if (book != null)
            {
                return Ok(BookToBookViewModelMapper.BookToBookViewModel(book));
            }

            return NotFound();
        }

        [HttpPost("add", Name = "AddBook")]
        public async Task<IActionResult> AddBook([FromBody] IServices.Requests.AddBook book)
        {
            var bookDAO = await _bookService.AddBook(book);
            return Created(bookDAO.BookId.ToString(), BookToBookViewModelMapper.BookToBookViewModel(bookDAO));
        }

        [HttpPatch("{bookId:min(1)}", Name = "EditBook")]
        public async Task<IActionResult> EditBook(int bookId, [FromBody] IServices.Requests.EditBook book)
        {
            await _bookService.EditBook(bookId, book);
            return NoContent();
        }

        [HttpPatch("{bookId:min(1)}/price", Name = "UpdateBookPrice")]
        public async Task<IActionResult> UpdateBookPrice(int bookId, [FromBody] IServices.Requests.UpdateBookPrice book)
        {
            await _bookService.UpdateBookPrice(book, bookId);
            return NoContent();
        }

        [HttpDelete("{bookId:min(1)}", Name = "DeleteBook")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBook(bookId);
            return NoContent();
        }
        
        [HttpGet("list", Name = "ListBooks")]
        public async Task<IActionResult> ListBooks()
        {
            var books = await _bookService.ListBooks();
            return Ok(books.Select(b => BookToBookViewModelMapper.BookToBookViewModel(b)));
        }
    }
}