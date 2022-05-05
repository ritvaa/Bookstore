namespace Bookstore.Data.Sql.DAO;

public class Publisher
{
    public Publisher()
    {
        Books = new List<Book>();
    }
    
    public int PublisherId { get; set; }
    public string PublisherName { get; set; }
    
    
    public virtual ICollection<Book> Books { get; set; }
}