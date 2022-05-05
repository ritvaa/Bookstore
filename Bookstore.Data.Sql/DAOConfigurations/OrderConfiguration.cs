using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.OrderId).IsRequired();
            builder.Property(c => c.OrderDate).IsRequired();
            builder.Property(c => c.ClientId).IsRequired();
            builder.Property(c => c.Quantity).IsRequired();
            // builder.Property(c => c.BookId).IsRequired();
            builder.HasOne(x => x.Client)
                .WithMany(x => x.Orders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ClientId);
            builder.ToTable("Order");
        }
    }

}