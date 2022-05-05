using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class BookConfiguration: IEntityTypeConfiguration<DAO.Book>
    {
        public void Configure(EntityTypeBuilder<DAO.Book> builder)
        {
            builder.Property(c => c.BookId).IsRequired();    
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            
            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Books)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PublisherId);
            builder.ToTable("Book");
        }
    }

}