using ProductStore.Persistance.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductStore.Persistance.Repository
{
    public class ProductRespository : IProductRespository
    {
        public ProductStoreContext _context { get; set; }

        public ProductRespository(string connectionString)
        {
            _context = new ProductStoreContext(connectionString);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public RepositoryActionResult<Product> Delete(int id)
        {
            try
            {
                var productExisting = _context.Products
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                if (productExisting != null)
                {
                    _context.Products.Remove(productExisting);
                    _context.SaveChanges();

                    return new RepositoryActionResult<Product>(null, RepositoryActionStatus.Deleted);
                }

                return new RepositoryActionResult<Product>(null, RepositoryActionStatus.NotFound);

            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Product>(null, RepositoryActionStatus.Error, ex);
            }
        }
        public RepositoryActionResult<Product> Add(Product product)
        {
            try
            {
                _context.Products.Add(product);

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<Product>(product,
                        RepositoryActionStatus.Created);
                }

                return new RepositoryActionResult<Product>(product,
                    RepositoryActionStatus.NothingModified, null);
            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Product>(product,
                    RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Product> Edit(Product product)
        {
            try
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);

                if (existingProduct == null)
                {
                    return new RepositoryActionResult<Product>(product, RepositoryActionStatus.NotFound);
                }

                _context.Entry(existingProduct).State = System.Data.Entity.EntityState.Detached;

                _context.Products.Attach(product);

                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<Product>(product, RepositoryActionStatus.Edited);
                }
                else
                {
                    return new RepositoryActionResult<Product>(product, RepositoryActionStatus.NothingModified);
                }
            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Product>(product, RepositoryActionStatus.Error, ex);
            }
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
