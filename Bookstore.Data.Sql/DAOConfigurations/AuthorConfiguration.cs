using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class AuthorConfiguration: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        { 
            builder.Property(c => c.AuthorId).IsRequired();  
            builder.Property(c => c.FirstName).IsRequired();  
            builder.Property(c => c.LastName).IsRequired();    

            builder.ToTable("Author");
        }
    }

}