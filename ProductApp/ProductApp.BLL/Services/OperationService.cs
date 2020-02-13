using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ProductApp.BLL.Interfaces;
using ProductApp.BLL.Models;
using ProductApp.DAL.Constants;
using ProductApp.DAL.Entities;
using ProductApp.DAL.Interfaces;

namespace ProductApp.BLL.Services
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

        public async Task<OperationDTO> AddOperation(OperationDTO model)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var product = await uow.ProductRepository.GetItem(model.ProductId);
                ProductDTO productDTO = mapper.Map<ProductDTO>(product);

                CheckModelValidation(model, productDTO);

                if (model.OperationType == OperationType.Outcome)
                    productDTO.Count -= model.Amount;
                else
                    productDTO.Count += model.Amount;

                await uow.OperationRepository.Create(mapper.Map<Operation>(model));
                uow.ProductRepository.Update(mapper.Map<Product>(productDTO));
                await uow.Save();
                scope.Complete();
            }
            return model;
        }

        public void CheckModelValidation(OperationDTO model, ProductDTO item)
        {
            if (model.Amount > 1000 || model.Amount <= 0)
                throw new ArgumentOutOfRangeException();
            if (model.OperationType == OperationType.Outcome && item.Count < model.Amount)
                throw new ArgumentException();
        }
    }
}