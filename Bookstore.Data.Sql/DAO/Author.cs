namespace Bookstore.Data.Sql.DAO;

public class Author
{
    public Author()
    {
        BookAuthors = new List<BookAuthor>();
    }
    
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual ICollection<BookAuthor> BookAuthors { get; set; }
}