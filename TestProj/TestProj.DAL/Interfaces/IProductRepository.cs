using System.Collections.Generic;
using System.Threading.Tasks;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
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
