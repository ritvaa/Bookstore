using System.Collections.Generic;

namespace Bookstore.Data.Sql.DAO
{
    public class Book {
        public Book()
        {
            BookOrders = new List<BookOrder>();
            BookAuthors = new List<BookAuthor>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // public int Amount { get; set; }
        //Czy to nie powinno być w BookOrder? 
        public decimal Price { get; set; }
        public string? ImageHref { get; set; } 
        public virtual int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookOrder> BookOrders { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}