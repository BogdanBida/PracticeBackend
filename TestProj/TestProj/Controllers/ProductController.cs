using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Interfaces;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        //GET: api/Product
        public IEnumerable<Product> GetProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpGet]
        [Route("{id}")]
        //GET: api/Product/id
        public Product GetProductDetails(int id)
        {
            return productService.GetProductById(id);
        }

        [HttpPost]
        //GET: api/Product
        public Product CreateProduct(Product model)
        {
            return productService.AddProduct(model);
        }

        [HttpDelete]
        [Route("{id}")]
        //GET: api/Product/id
        public Product DeleteProduct(int id)
        {
            return productService.DeleteProductById(id);
        }

        [HttpPut]
        //GET: api/Product
        public Product UpdateProduct(Product modelChanges)
        {
            try
            {
                return productService.ChangeProduct(modelChanges);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}