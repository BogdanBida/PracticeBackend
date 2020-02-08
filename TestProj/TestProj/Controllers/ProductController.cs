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
        public IActionResult GetProductDetails(int id)
        {
            var item = productService.GetProductById(id);
            if (item == null)
                return BadRequest(new { message = "This product doesn't exist." });
            return Ok(item);
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
        public IActionResult DeleteProduct(int id)
        {
            var item = productService.DeleteProductById(id);
            if(item == null)
                return BadRequest(new { message = "This product doesn't exist." });
            return Ok(item);
        }

        [HttpPut]
        //GET: api/Product
        public IActionResult UpdateProduct(ProductDTO modelChanges)
        {
            try
            {
                return Ok(productService.ChangeProduct(modelChanges));
            }
            catch
            {
                return BadRequest(new { message = "This product doesn't exist." });
            }
        }
    }
}