using AutoMapper;
using System;
using System.Collections.Generic;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.BLL.Services
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

        public ProductDTO GetProductById(int id)
        {
            var item = uow.ProductRepository.GetItem(id);
            return mapper.Map<ProductDTO>(item);
        }

        public ProductDTO AddProduct(ProductDTO model)
        {
            if(model.Price < 10000)
            {
                uow.ProductRepository.Create(mapper.Map<Product>(model));
                uow.Save();
                return model;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public ProductDTO ChangeProduct(ProductDTO modelChanges)
        {
            if (modelChanges.Price < 10000)
            {
                uow.ProductRepository.Update(mapper.Map<Product>(modelChanges));
                uow.Save();
                return modelChanges;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public ProductDTO DeleteProductById(int id)
        {
            var item = uow.ProductRepository.Delete(id);
            uow.Save();
            return mapper.Map<ProductDTO>(item);
        }
    }
}
