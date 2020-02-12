using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.BLL.Interfaces;
using ProductApp.BLL.Models;
using ProductApp.DAL.Entities;
using ProductApp.DAL.Interfaces;

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

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = uow.ProductRepository.GetItemList();
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
            uow.Save();
            return model;
        }

        public ProductDTO ChangeProduct(ProductDTO modelChanges)
        {
            modelChanges = ValidateModel(modelChanges);
            uow.ProductRepository.Update(mapper.Map<Product>(modelChanges));
            uow.Save();
            return modelChanges;
        }

        public void DeleteProductById(int id)
        {
            uow.ProductRepository.Delete(id);
            uow.Save();
        }

        public ProductDTO ValidateModel(ProductDTO model)
        {
            if (model.Name.Length >= 50)
                throw new ArgumentException();
            model.Price = Math.Round(model.Price, 2, MidpointRounding.AwayFromZero);
            if (model.Price >= 10000 || model.Price <= 0)
                throw new ArgumentOutOfRangeException();
            return model;
        }
    }
}
