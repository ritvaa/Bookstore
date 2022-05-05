using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.Sql.DAO;

public class Client
{

    public Client()
    {
        Orders = new List<Order>();
    }


    public int ClientId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Street { get; set; }
    public string HouseNo { get; set; }
    
    public string? ApartamentNo { get; set; }
    
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; }


}