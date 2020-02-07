using AutoMapper;
using System.Collections.Generic;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repo;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = repo.GetItemList();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int id)
        {
            var item = repo.GetItem(id);
            ProductDTO productDTO =  mapper.Map<ProductDTO>(item);
            return productDTO;
        }

        public ProductDTO AddProduct(ProductDTO model)
        {
            repo.Create(mapper.Map<Product>(model));
            return model;
        }

        public ProductDTO ChangeProduct(ProductDTO modelChanges)
        {
            repo.Update(mapper.Map<Product>(modelChanges));
            return modelChanges;
        }

        public ProductDTO DeleteProductById(int id)
        {
            var item = repo.Delete(id);
            return mapper.Map<ProductDTO>(item);
        }
    }
}
