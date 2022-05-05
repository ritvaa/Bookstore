using System;

namespace Bookstore.Api.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public string? ImageHref { get; set; }
        
        public int PublisherId { get; set; }
    }
}