using ProductStore.Persistance.Entities;
using ProductStore.Persistance.EntitiesConfiguration;
using System.Data.Entity;

namespace ProductStore.Persistance
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext()
        {
        }

        public ProductStoreContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
