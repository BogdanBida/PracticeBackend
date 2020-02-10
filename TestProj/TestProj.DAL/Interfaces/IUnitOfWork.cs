using System;
using System.Collections.Generic;
using System.Text;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Operation> OperationRepository { get; }
        void Save();
    }
}
