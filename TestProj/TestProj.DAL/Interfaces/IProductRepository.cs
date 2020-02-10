using System.Collections.Generic;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IProductRepository
    {
        Product GetItem(int id);
        IEnumerable<Product> GetItemList();
        Product Create(Product item);
        Product Update(Product item);
        Product Delete(int id);
    }
}
