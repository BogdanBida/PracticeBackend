using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IOperationRepository
    {
        IQueryable<Operation> GetOperations(int id);
        Operation Create(Operation item);
    }
}
