using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Bookstore.Data.Sql.Book;
using Bookstore.Data.Sql.DAO;
using Bookstore.IData.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Sdk;

namespace Bookstore.Data.Sql.Tests;

public class BookRepositoryTests : IAsyncLifetime
{
    public IConfiguration Configuration { get; }
    private BookstoreDbContext _context;
    private IBookRepository _bookRepository;

    public BookRepositoryTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookstoreDbContext>();
        optionsBuilder.UseMySQL(
            "server=localhost;userid=root;port=3306;database=bookstore_db;");
        _context = new BookstoreDbContext(optionsBuilder.Options);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _bookRepository = new BookRepository(_context);

    }
    
    public async Task InitializeAsync()
    {
        var publisher = new Publisher
        {
            PublisherId  = 1,
            PublisherName = "Publisher 1"
        };
        
        await _context.AddAsync(publisher);
        await _context.SaveChangesAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }


    [Fact]
    public async Task AddBook_Returns_Correct_Response()
    {
        var Book = new Domain.Book.Book("Title", "Description", (decimal) 10.00, "Image", 1);

        var BookId = await _bookRepository.AddBook(Book);

        var AddedBook = await _context.Book.FirstOrDefaultAsync(x => x.BookId == BookId);
        Assert.NotNull(AddedBook);

        _context.Book.Remove(AddedBook);
        await _context.SaveChangesAsync();
    }

    
}