using EasyCrud.Domain;
using System.Data.Entity.ModelConfiguration;

namespace EasyCrud.DataContext.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Client");
            HasKey(a => a.ClientId);
            Property(a => a.Name).IsRequired().HasMaxLength(255);
            Property(a => a.Email).IsRequired().HasMaxLength(300);
            Property(a => a.Birthdate).IsRequired();
            Property(a => a.Address).IsRequired().HasMaxLength(400);
            HasMany(a => a.Product).WithMany(a => a.Clients).Map(a => a.ToTable("ClientProduct"));
        }
    }
}
