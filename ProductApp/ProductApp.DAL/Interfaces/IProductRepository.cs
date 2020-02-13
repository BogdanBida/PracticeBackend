using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.DAL.Entities;
using ProductApp.DAL.Paging;

namespace ProductApp.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetItem(int id);
        IQueryable<Product> GetAllItems();
        IQueryable<Product> GetAllItemsSorted(ProductPagingParams pagingParams);
        IEnumerable<Product> GetItemsSegment(ProductPagingParams pagingParams);
        Task<Product> Create(Product item);
        Product Update(Product item);
        Task Delete(int id);
    }
}
