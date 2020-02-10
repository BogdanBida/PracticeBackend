using System;
using System.Collections.Generic;
using System.Text;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IOperationRepository OperationRepository { get; }
        void Save();
    }
}
