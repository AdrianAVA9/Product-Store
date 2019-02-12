using ProductStore.Persistance.Entities;
using System.Collections.Generic;

namespace ProductStore.Persistance.Repository
{
    public interface IProductRespository
    {
        ProductStoreContext _context { get; set; }

        IEnumerable<Product> GetProducts();
        RepositoryActionResult<Product> Add(Product product);
        RepositoryActionResult<Product> Delete(int id);
        RepositoryActionResult<Product> Edit(Product product);
        Product GetProduct(int id);
    }
}