using ProductStore.Persistance.Repository;

namespace ProductStore.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRespository ProductRepository { get; private set; }

        public UnitOfWork(string connectionString)
        {
            ProductRepository = new ProductRespository(connectionString);
        }
    }

    public interface IUnitOfWork
    {
        IProductRespository ProductRepository { get; }
    }
}
