using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestProj.DAL.EF;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.DAL.Repositories
{
    public class MsSqlProductRepository : IRepository<Product>
    {
        private readonly ApplicationContext dbContext;

        public MsSqlProductRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product GetItem(int id)
        {
            return dbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetItemList()
        {
            return dbContext.Products;
        }

        public Product Create(Product model)
        {
            dbContext.Products.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public Product Delete(int id)
        {
            Product model = GetItem(id);
            if (model != null)
            {
                dbContext.Products.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public Product Update(Product modelChanges)
        {
            var model = dbContext.Products.Attach(modelChanges);
            model.State = EntityState.Modified;
            dbContext.SaveChanges();
            return modelChanges;
        }
    }
}
