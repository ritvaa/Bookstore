using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class BookAuthorConfiguration: IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAuthors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.BookId);
            
            builder.HasOne(x => x.Author)
                .WithMany(x => x.BookAuthors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AuthorId);
            
            builder.ToTable("BookAuthor");
        }
    }
}