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
    }
}