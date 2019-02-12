using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using ProductStore.Dtos;
using ProductStore.Persistance.Entities;
using ProductStore.WebApi.Autofac.Modules;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(ProductStore.WebApi.Startup))]

namespace ProductStore.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            var autoMapperConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDto>();
                c.CreateMap<ProductDto, Product>();
                c.CreateMap<ProductForCreation, Product>();
            });

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<ProductStoreModule>();
            builder.RegisterInstance(autoMapperConfig.CreateMapper());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
