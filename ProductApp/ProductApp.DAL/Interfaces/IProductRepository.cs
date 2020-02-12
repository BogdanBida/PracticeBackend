using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.DAL.Entities;

namespace ProductApp.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetItem(int id);
        IEnumerable<Product> GetItemList();
        Task<Product> Create(Product item);
        Product Update(Product item);
        void Delete(int id);
    }
}
