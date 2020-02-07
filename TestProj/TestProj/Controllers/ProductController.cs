using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;

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
        public IEnumerable<ProductDTO> GetProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpGet]
        [Route("{id}")]
        //GET: api/Product/id
        public ProductDTO GetProductDetails(int id)
        {
            return productService.GetProductById(id);
        }

        [HttpPost]
        //GET: api/Product
        public ProductDTO CreateProduct(ProductDTO model)
        {
            return productService.AddProduct(model);
        }

        [HttpDelete]
        [Route("{id}")]
        //GET: api/Product/id
        public ProductDTO DeleteProduct(int id)
        {
            return productService.DeleteProductById(id);
        }

        [HttpPut]
        //GET: api/Product
        public ProductDTO UpdateProduct(ProductDTO modelChanges)
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