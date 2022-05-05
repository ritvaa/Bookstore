using Bookstore.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Data.Sql.DAOConfigurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.ClientId).IsRequired();
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.PhoneNo).IsRequired();
            builder.Property(c => c.Street).IsRequired();
            builder.Property(c => c.HouseNo).IsRequired();
            builder.Property(c => c.City).IsRequired();
            builder.Property(c => c.ZipCode).IsRequired();

            builder.ToTable("Client");
        }
    }

}