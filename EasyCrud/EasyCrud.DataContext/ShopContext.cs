using EasyCrud.DataContext.Mapping;
using EasyCrud.Domain;
using System.Data.Entity;

namespace EasyCrud.DataContext
{
    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("ShopConnection")
        {
            Database.SetInitializer<ShopContext>(new ShopDataContextInitializer());
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ClientMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ShopDataContextInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            base.Seed(context);
        }
    }
}
