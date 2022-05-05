using Bookstore.Data.Sql.DAO;
using Bookstore.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Sql
{
    //Klasa odpowiadająca za konfigurację Entity Framework Core
    //Przy pomocy instancji klasy FoodlyDbContext możliwe jest wykonywanie
    //wszystkich operacji na bazie danych od tworzenia bazy danych po zapytanie do bazy danych itd.
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) {}
        
        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<Author> Author { get; set; }        
        public virtual DbSet<DAO.Book> Book { get; set; }        
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }        
        public virtual DbSet<BookOrder> BookOrder { get; set; }        
        public virtual DbSet<Client> Client { get; set; }        
        public virtual DbSet<Order> Order { get; set; }        
        public virtual DbSet<Publisher> Publisher { get; set; }

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookAuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookOrderConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new PublisherConfiguration());
        }
    }
}