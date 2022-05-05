namespace Bookstore.Data.Sql.DAO;

public class BookAuthor
{
    public int BookAuthorId { get; set; }
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    
    virtual public Book Book { get; set; }
    virtual public Author Author { get; set; }
}