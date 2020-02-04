using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestProj.Models
{
    public class MsSqlProductRepository : IRepository<ProductModel>
    {
        private readonly ApplicationContext dbContext;

        public MsSqlProductRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ProductModel GetItem(int id)
        {
            return dbContext.Products.Find(id);
        }

        public IEnumerable<ProductModel> GetItemList()
        {
            return dbContext.Products;
        }

        public ProductModel Create(ProductModel model)
        {
            dbContext.Products.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public ProductModel Delete(int id)
        {
            ProductModel model = GetItem(id);
            if (model != null)
            {
                dbContext.Products.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public ProductModel Update(ProductModel modelChanges)
        {
            var model = dbContext.Products.Attach(modelChanges);
            model.State = EntityState.Modified;
            dbContext.SaveChanges();
            return modelChanges;
        }
    }
}
