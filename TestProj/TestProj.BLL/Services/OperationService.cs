﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.BLL.Services
{
    public class OperationService : IOperationService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public OperationService(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }
        public IEnumerable<OperationDTO> GetAllOperations(int productId)
        {
            IQueryable<Operation> operations = uow.OperationRepository.GetOperations(productId);
            return mapper.Map<IEnumerable<OperationDTO>>(operations.AsEnumerable());
        }

        public OperationDTO AddOperation(OperationDTO model)
        {
            var product = uow.ProductRepository.GetItem(model.ProductId);
            ProductDTO productDTO = mapper.Map<ProductDTO>(product);

            if (model.OperationType == OperationType.Income)
                productDTO.Count += model.Amount;
            else
            {
                if (productDTO.Count >= model.Amount)
                    productDTO.Count -= model.Amount;
                else
                    throw new ArgumentException();
            }

            uow.OperationRepository.Create(mapper.Map<Operation>(model));
            uow.ProductRepository.Update(mapper.Map<Product>(productDTO));
            uow.Save();
            return model;
        }
    }
}
