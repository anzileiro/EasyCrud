using EasyCrud.Domain;
using System.Data.Entity.ModelConfiguration;

namespace EasyCrud.DataContext.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(a => a.ProductId);
            Property(a => a.Name).IsRequired().HasMaxLength(255);
            Property(a => a.Price).IsRequired();
            Property(a => a.Quantity).IsRequired();
            HasMany(a => a.Clients).WithMany(a => a.Product).Map(a => a.ToTable("ClientProduct"));
        }
    }
}
