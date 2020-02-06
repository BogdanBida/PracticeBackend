using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<Product> repo;

        public HomeController(IRepository<Product> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("ListProducts")]
        //GET: api/Home/ListProducts
        public IEnumerable<Product> GetProducts()
        {
            return repo.GetItemList();
        }

        [HttpGet]
        [Route("ProductDetails/{id}")]
        //GET: api/Home/ProductDetails/id
        public Product GetProductDetails(int id)
        {

            var result = repo.GetItem(id);
            return result;
        }

        [HttpPost]
        [Route("CreateProduct")]
        //GET: api/Home/CreateProduct
        public Product CreateProduct(Product model)
        {
            repo.Create(model);
            return (model);
        }

        [HttpPost]
        [Route("DeleteProduct/{id}")]
        //GET: api/Home/DeleteProdu ct/id
        public Product DeleteProduct(int id)
        {
            return repo.Delete(id);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        //GET: api/Home/UpdateProduct
        public Product UpdateProduct(Product modelChanges)
        {
            try
            {
                return repo.Update(modelChanges);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}