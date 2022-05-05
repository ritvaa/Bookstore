namespace Bookstore.Data.Sql.DAO;

public class Order
{
    public Order()
    {
        BookOrders = new List<BookOrder>();
    }
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    
    public virtual Client Client { get; set; }
    public virtual ICollection<BookOrder> BookOrders { get; set; }
}