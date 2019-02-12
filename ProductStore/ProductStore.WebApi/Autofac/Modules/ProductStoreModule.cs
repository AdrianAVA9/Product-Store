using Autofac;
using ProductStore.Manager;
using ProductStore.Persistance;
using System.Configuration;

namespace ProductStore.WebApi.Autofac.Modules
{
    public class ProductStoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var unitOfWork = new UnitOfWork(
                ConfigurationManager.ConnectionStrings["ProductStoreCS"].ConnectionString);

            builder.Register(p => new ProductManager(unitOfWork))
                .AsImplementedInterfaces().AsSelf();

            base.Load(builder);
        }
    }
}