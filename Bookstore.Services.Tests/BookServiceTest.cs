using System.Threading.Tasks;
using Bookstore.Domain.DomainExceptions;
using Bookstore.IData.Book;
using Bookstore.IServices.Book;
using Bookstore.IServices.Requests;
using Bookstore.Services.Book;
using Xunit;
using Moq;

namespace Bookstore.Services.Tests;

public class BookstoreServiceTests
{
    private readonly IBookService _bookService;
    private readonly Mock<IBookRepository> _bookRepositoryMock;

    public BookstoreServiceTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _bookService = new BookService(_bookRepositoryMock.Object);
    }

    [Fact]
    public void AddBook_Returns_throw_InvalidTitleException()
    {
        var book = new AddBook
        {
            Title = "E,mjkwEm_-:!%-NFDYL]-9i-p9Y?MFM!/b7bUBataa",
            Description = "Desctiption",
            Price = (decimal) 10.00,
            ImageHref = "ImageHref",
            PublisherId = 1
        };
        
        Assert.ThrowsAsync<InvalidTitleException>(() => _bookService.AddBook(book));
    }

    [Fact]
    public async Task AddBook_Returns_Correct_Response()
    {
        var book = new AddBook
        {
            Title = "Title",
            Description = "Desctiption",
            Price = (decimal) 10.00,
            ImageHref = "ImageHref",
            PublisherId = 1
        };
        
        int expectedResult = 420;
        _bookRepositoryMock.Setup(x => x.AddBook
            (new Domain.Book.Book
                (book.Title, 
                    book.Description, 
                    book.Price, 
                    book.ImageHref, 
                    book.PublisherId)))
            .Returns(Task.FromResult(expectedResult));
        
        var result = await _bookService.AddBook(book);
        
        Assert.IsType<Domain.Book.Book>(result);
        Assert.NotNull(result);
        Assert.Equal(expectedResult, result.BookId);
    }
}