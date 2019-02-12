using ProductStore.Persistance.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProductStore.Persistance.EntitiesConfiguration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Description)
                .IsRequired();

            Property(p => p.ImageUrl)
                .IsRequired();

            Property(p => p.Owner)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Price)
                .IsRequired();

            Property(p => p.Rating)
                .IsOptional();
        }
    }
}
