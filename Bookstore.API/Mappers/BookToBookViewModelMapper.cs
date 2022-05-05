using Bookstore.Api.ViewModels;
using Bookstore.Data.Sql.DAO;

namespace Bookstore.Api.Mappers
{
    public class BookToBookViewModelMapper
    {
        public static BookViewModel BookToBookViewModel(Domain.Book.Book book)
        {
            var bookViewModel = new BookViewModel()
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                ImageHref = book.ImageHref,
                PublisherId = book.PublisherId
            };
            
            return bookViewModel;
        }

    }
}