using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class PublisherConfiguration: IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(c => c.PublisherId).IsRequired();  
            builder.Property(c => c.PublisherName).IsRequired();
            builder.ToTable("Publisher");
        }
    }

}