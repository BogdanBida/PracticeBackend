using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Constants;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var item = await productService.GetProductById(id);
            if (item == null)
                return BadRequest(ErrorMessages.ProductNotFound);
            return Ok(item);
        }

        [HttpPost]
        //GET: api/Product
        public async Task<IActionResult> CreateProduct(ProductDTO model)
        {
            try
            {
                var item = await productService.AddProduct(model);
                return Ok(item);
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest(ErrorMessages.InvalidPrice);
            }
            catch (ArgumentException)
            {
                return BadRequest(ErrorMessages.InvalidProductName);
            }
            catch
            {
                return BadRequest(ErrorMessages.ProductAlreadyExists);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        //GET: api/Product/id
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productService.DeleteProductById(id);
                return Ok();
            }
            catch
            {
                return BadRequest(ErrorMessages.ProductNotFound);
            }
        }

        [HttpPut]
        //GET: api/Product
        public IActionResult UpdateProduct(ProductDTO modelChanges)
        {
            try
            {
                return Ok(productService.ChangeProduct(modelChanges));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest(ErrorMessages.InvalidPrice);
            }
            catch (ArgumentException)
            {
                return BadRequest(ErrorMessages.InvalidProductName);
            }
            catch
            {
                return BadRequest(ErrorMessages.ProductAlreadyExists);
            }
        }
    }
}