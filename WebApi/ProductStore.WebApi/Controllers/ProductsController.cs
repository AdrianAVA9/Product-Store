using AutoMapper;
using ProductStore.Dtos;
using ProductStore.Manager;
using ProductStore.Persistance.Entities;
using ProductStore.WebApi.Helper;
using System;
using System.Web.Http;

namespace ProductStore.WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        public IMapper _mapper { get; set; }
        public IProductManager ProductManager { get; set; }

        public ProductsController(IMapper mapper, IProductManager productManager)
        {
            _mapper = mapper;
            ProductManager = productManager;
        }

        [HttpPost]
        public IHttpActionResult AddProduct([FromBody]ProductForCreation productForCreation)
        {
            try
            {
                if (productForCreation == null) return BadRequest();

                var product = _mapper.Map<Product>(productForCreation);
                product.ImageUrl = new CreatePicture().Create(productForCreation.Picture);

                if (product.ImageUrl == null) return BadRequest();

                var result = ProductManager.AddProduct(product);

                if (result.Status == Persistance.RepositoryActionStatus.Created)
                {
                    return Created(Request.RequestUri + "/" + result.Entity.Id.ToString(),
                        _mapper.Map<ProductDto>(result.Entity));
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            try
            {
                var products = ProductManager.GetProducts();

                foreach (var product in products)
                {
                    product.ImageUrl = Request.RequestUri.AbsoluteUri.Replace("api/products",
                        "images/products?imageId=" + product.ImageUrl);
                }

                return Ok(_mapper.Map<ProductDto[]>(products));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                var product = ProductManager.GetProduct(id);

                return Ok(_mapper.Map<ProductDto>(product));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                var result = ProductManager.DeleteProduct(id);

                if (result.Status == Persistance.RepositoryActionStatus.Deleted)
                {
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
                else if (result.Status == Persistance.RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult PutProduct([FromBody] Product product)
        {
            try
            {
                if (product == null) return BadRequest();

                var result = ProductManager.EditProduct(product);

                if (result.Status == Persistance.RepositoryActionStatus.Edited)
                {
                    return Ok(_mapper.Map<ProductDto>(result.Entity));
                }
                else if (result.Status == Persistance.RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
