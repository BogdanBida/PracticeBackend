﻿using Microsoft.EntityFrameworkCore;
using System;
using ProductApp.DAL.EF;
using ProductApp.DAL.Interfaces;
using System.Threading.Tasks;

namespace ProductApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext dbContext;
        private IProductRepository prodsRepo;
        private IOperationRepository opsRepo;

        public UnitOfWork(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (prodsRepo == null)
                    prodsRepo = new ProductRepository(dbContext);
                return prodsRepo;
            }
        }

        public IOperationRepository OperationRepository
        {
            get
            {
                if (opsRepo == null)
                    opsRepo = new OperationRepository(dbContext);
                return opsRepo;
            }
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}