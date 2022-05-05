using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class BookOrderConfiguration: IEntityTypeConfiguration<BookOrder>
    {
        public void Configure(EntityTypeBuilder<BookOrder> builder)
        {
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.BookId);
            
            builder.HasOne(x => x.Order)
                .WithMany(x => x.BookOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OrderId);
   

            builder.ToTable("BookOrder");
        }
    }

}