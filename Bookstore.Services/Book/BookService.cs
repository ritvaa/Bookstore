using System.Threading.Tasks;
using Bookstore.IData.Book;
using Bookstore.IServices.Requests;
using Bookstore.IServices.Book;

namespace Bookstore.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }
        
        public Task<Domain.Book.Book> GetBookByBookId(int bookId)
        {
            return _BookRepository.GetBookById(bookId);
        }

        public Task<Domain.Book.Book> GetBookByTitle(string bookName)
        {
            return _BookRepository.GetBookByTitle(bookName);
        }

        public async Task<Domain.Book.Book> AddBook(AddBook addBook)
        {
            var book = new Domain.Book.Book(addBook.Title, addBook.Description, addBook.Price, addBook.ImageHref,
                addBook.PublisherId);
            var bookId = await _BookRepository.AddBook(book);
            book.BookId = bookId;
            return book;
        }

        public async Task EditBook(int bookId, EditBook editBook)
        {
            var book = new Domain.Book.Book(bookId, editBook.Title, editBook.Description, editBook.Price,
                editBook.ImageHref, editBook.PublisherId);
            await _BookRepository.EditBook(bookId, book);
        }

        public async Task UpdateBookPrice(UpdateBookPrice updateBookPrice, int bookId)
        {
            var book = await _BookRepository.GetBookById(bookId);
            book.Price = updateBookPrice.Price;

            await _BookRepository.EditBook(bookId, book);
        }

        public async Task DeleteBook(int bookId)
        {
            await _BookRepository.DeleteBook(bookId);
        }
        
        public async Task<List<Domain.Book.Book>> ListBooks()
        {
            return await _BookRepository.ListBooks();
        }
    }
}