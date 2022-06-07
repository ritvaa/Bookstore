using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.IData.Book
{
    public interface IBookRepository
    {
        Task<Bookstore.Domain.Book.Book> GetBookByTitle(string title);
        Task<Bookstore.Domain.Book.Book> GetBookById(int id);
        Task<int> AddBook(Bookstore.Domain.Book.Book book);
        Task EditBook(int bookId, Domain.Book.Book book);
        Task DeleteBook(int id);
        Task<List<Bookstore.Domain.Book.Book>> ListBooks();

    }
}