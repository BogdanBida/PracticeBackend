using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.DAL.Constants;
using ProductApp.DAL.EF;
using ProductApp.DAL.Entities;
using ProductApp.DAL.Interfaces;
using ProductApp.DAL.Paging;

namespace ProductApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext dbContext;

        public ProductRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> GetItem(int id)
        {
            return await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public IQueryable<Product> GetAllItems()
        {
            return dbContext.Products;
        }

        public IQueryable<Product> GetAllItemsSorted(ProductPagingParams pagingParams)
        {
            var list = GetAllItems();
            switch (pagingParams.SortOrder)
            {
                case SortState.NameDesc:
                    list = list.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    list = list.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    list = list.OrderByDescending(s => s.Price);
                    break;
                default:
                    list = list.OrderBy(s => s.Name);
                    break;
            }
            return list;
        }

        public IEnumerable<Product> GetItemsSegment(ProductPagingParams pagingParams)
        {
            var products = GetAllItemsSorted(pagingParams);
            return PagedList<Product>.ToPagedList(products,
                pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<Product> Create(Product model)
        {
            await dbContext.Products.AddAsync(model);
            return model;
        }

        public async Task Delete(int id)
        {
            Product model = await GetItem(id);
            if (model != null)
            {
                dbContext.Products.Remove(model);
            }
        }

        public Product Update(Product modelChanges)
        {
            var model = dbContext.Products.Attach(modelChanges);
            model.State = EntityState.Modified;
            return modelChanges;
        }
    }
}
