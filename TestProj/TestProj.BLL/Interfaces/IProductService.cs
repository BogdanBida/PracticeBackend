using System.Collections.Generic;
using System.Threading.Tasks;
using TestProj.BLL.Models;

namespace TestProj.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> AddProduct(ProductDTO model);
        void DeleteProductById(int id);
        ProductDTO ChangeProduct(ProductDTO modelChanges);
    }
}
