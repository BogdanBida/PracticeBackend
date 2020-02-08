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
        public IActionResult CreateProduct(ProductDTO model)
        {
            try
            {
                var item = productService.AddProduct(model);
                return Ok(item);
            }
            catch
            {
                return BadRequest(new { message = "This product cannot be added." });
            }
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