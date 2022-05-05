namespace Bookstore.Data.Sql.DAO;

public class BookOrder
{
    public int BookOrderId { get; set; }
    public int BookId { get; set; }
    public int OrderId { get; set; }
    
    public virtual Order Order { get; set; }
    public virtual Book Book { get; set; }
}