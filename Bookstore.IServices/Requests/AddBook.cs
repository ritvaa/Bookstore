namespace Bookstore.IServices.Requests
{
    public class AddBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageHref { get; set; }
        public int PublisherId { get; set; }
    }
}