using System;

namespace ProductApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IOperationRepository OperationRepository { get; }
        void Save();
    }
}
