using System.Collections.Generic;
using TestProj.BLL.Models;

namespace TestProj.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO AddProduct(ProductDTO model);
        ProductDTO DeleteProductById(int id);
        ProductDTO ChangeProduct(ProductDTO modelChanges);
    }
}
