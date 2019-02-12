using ProductStore.Persistance;
using ProductStore.Persistance.Entities;
using System.Collections.Generic;

namespace ProductStore.Manager
{
    public class ProductManager : IProductManager
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RepositoryActionResult<Product> AddProduct(Product product)
        {
            return _unitOfWork.ProductRepository.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetProducts();
        }

        public RepositoryActionResult<Product> DeleteProduct(int id)
        {
            return _unitOfWork.ProductRepository.Delete(id);
        }

        public RepositoryActionResult<Product> EditProduct(Product product)
        {
            return _unitOfWork.ProductRepository.Edit(product);
        }

        public Product GetProduct(int id)
        {
            return _unitOfWork.ProductRepository.GetProduct(id);
        }
    }

    public interface IProductManager
    {
        RepositoryActionResult<Product> AddProduct(Product product);
        RepositoryActionResult<Product> EditProduct(Product product);
        RepositoryActionResult<Product> DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
