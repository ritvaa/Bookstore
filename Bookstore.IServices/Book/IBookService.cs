using System.Threading.Tasks;
using Bookstore.IServices.Requests;

namespace Bookstore.IServices.Book
{
    public interface IBookService
    {
        Task<Bookstore.Domain.Book.Book> GetBookByBookId(int bookId);
        Task<Bookstore.Domain.Book.Book> GetBookByTitle(string bookName);
        Task<Domain.Book.Book> AddBook(AddBook addBook);
        Task EditBook(int bookId, EditBook editBook);
        Task UpdateBookPrice(UpdateBookPrice updateBookPrice, int bookId);
        Task DeleteBook(int bookId);
    }
}