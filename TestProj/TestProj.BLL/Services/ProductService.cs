using System;
using System.Collections.Generic;
using System.Text;
using TestProj.BLL.Interfaces;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repo;

        public ProductService(IRepository<Product> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetItemList();
        }

        public Product GetProductById(int id)
        {
            return repo.GetItem(id);
        }

        public Product AddProduct(Product model)
        {
            return repo.Create(model);
        }

        public Product ChangeProduct(Product modelChanges)
        {
            return repo.Update(modelChanges);
        }

        public Product DeleteProductById(int id)
        {
            return repo.Delete(id);
        }
    }
}
