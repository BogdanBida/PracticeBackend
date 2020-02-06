using System;
using System.Collections.Generic;
using System.Text;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product model);
        Product DeleteProductById(int id);
        Product ChangeProduct(Product modelChanges);
    }
}
