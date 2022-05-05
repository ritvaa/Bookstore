using System;

namespace Bookstore.Domain.Book
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageHref { get; set; }
        public virtual int PublisherId { get; set; }

        public Book(int id, string title, string description, decimal price, string? imageHref, int publisherId)
        {
            BookId = id;
            Title = title;
            Description = description;
            Price = price;
            ImageHref = imageHref;
            PublisherId = publisherId;
        }
        
        
        public Book(string title, string description, decimal price, string? imageHref, int publisherId)
        {
            Title = title;
            Description = description;
            Price = price;
            ImageHref = imageHref;
            PublisherId = publisherId;
        }
        
    }
}