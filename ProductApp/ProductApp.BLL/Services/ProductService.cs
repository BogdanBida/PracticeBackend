using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.BLL.Interfaces;
using ProductApp.BLL.Models;
using ProductApp.DAL.Entities;
using ProductApp.DAL.Interfaces;
using ProductApp.DAL.Paging;

namespace ProductApp.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ProductService(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public IEnumerable<ProductDTO> GetAllProducts(ProductPagingParams pagingParams)
        {
            var products = uow.ProductRepository.GetItemsSegment(pagingParams);
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var item = await uow.ProductRepository.GetItem(id);
            return mapper.Map<ProductDTO>(item);
        }

        public async Task<ProductDTO> AddProduct(ProductDTO model)
        {
            model = ValidateModel(model);
            await uow.ProductRepository.Create(mapper.Map<Product>(model));
            await uow.Save();
            return model;
        }

        public async Task<ProductDTO> ChangeProduct(ProductDTO modelChanges)
        {
            modelChanges = ValidateModel(modelChanges);
            uow.ProductRepository.Update(mapper.Map<Product>(modelChanges));
            await uow.Save();
            return modelChanges;
        }

        public async Task DeleteProductById(int id)
        {
            await uow.ProductRepository.Delete(id);
            await uow.Save();
        }

        public ProductDTO ValidateModel(ProductDTO model)
        {
            if (model.Name.Length >= 50 || model.Name.Length == 0)
                throw new ArgumentException();
            model.Price = Math.Round(model.Price, 2, MidpointRounding.AwayFromZero);
            if (model.Price >= 10000 || model.Price <= 0)
                throw new ArgumentOutOfRangeException();
            return model;
        }
    }
}
