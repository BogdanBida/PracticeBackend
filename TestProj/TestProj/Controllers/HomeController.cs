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
        //GET: api/Home
        public IEnumerable<Product> GetProducts()
        {
            return repo.GetItemList();
        }

        [HttpGet]
        [Route("{id}")]
        //GET: api/Home/id
        public Product GetProductDetails(int id)
        {

            var result = repo.GetItem(id);
            return result;
        }

        [HttpPost]
        //GET: api/Home
        public Product CreateProduct(Product model)
        {
            repo.Create(model);
            return (model);
        }

        [HttpDelete]
        [Route("{id}")]
        //GET: api/Home/id
        public Product DeleteProduct(int id)
        {
            return repo.Delete(id);
        }

        [HttpPut]
        //GET: api/Home
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