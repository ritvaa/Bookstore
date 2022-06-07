using System.Threading.Tasks;
using Bookstore.IData.Book;
using Bookstore.IData.Book;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Sql.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _context;

        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<Bookstore.Domain.Book.Book> GetBookByTitle(string title)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.Title == title);
            return new Domain.Book.Book(book.BookId, book.Title, book.Description, book.Price, book.ImageHref,
                book.PublisherId);
        }
        
        public async Task<Bookstore.Domain.Book.Book> GetBookById(int id)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.BookId == id);
            return new Domain.Book.Book(book.BookId, book.Title, book.Description, book.Price, book.ImageHref,
                book.PublisherId);
        }

        public async Task<int> AddBook(Domain.Book.Book Book)
        {
            var BookDAO = new DAO.Book
            {
                BookId = Book.BookId,
                Title = Book.Title,
                Description = Book.Description,
                Price = Book.Price,
                PublisherId = Book.PublisherId,
                ImageHref = Book.ImageHref,
            };
            await _context.AddAsync(BookDAO);
            await _context.SaveChangesAsync();
            return BookDAO.BookId;
        }

        public async Task EditBook(int bookId, Domain.Book.Book Book)
        {
            var editBook = await _context.Book.FirstOrDefaultAsync(b => b.BookId == Book.BookId);
            if (editBook == null)
            {
                throw new Exception("Book not found");
            }
            editBook.Title = Book.Title;
            editBook.Description = Book.Description;
            editBook.Price = Book.Price;
            editBook.PublisherId = Book.PublisherId;
            editBook.ImageHref = Book.ImageHref;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Book.FirstOrDefaultAsync(x => x.BookId == id);
            
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            _context.BookOrder.RemoveRange(_context.BookOrder.Where(x => x.BookId == id));
            _context.BookAuthor.RemoveRange(_context.BookAuthor.Where(x => x.BookId == id));
            _context.Book.Remove(book); 
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<Bookstore.Domain.Book.Book>> ListBooks()
        {
            var books = await _context.Book.ToListAsync();
            return books.Select(b => new Domain.Book.Book(b.BookId, b.Title, b.Description, b.Price, b.ImageHref,
                b.PublisherId)).ToList();
        }
        
    }
        
    
    }
