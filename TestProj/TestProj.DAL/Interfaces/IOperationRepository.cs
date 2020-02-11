using System.Linq;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IOperationRepository
    {
        IQueryable<Operation> GetOperations(int id);
        Operation Create(Operation item);
    }
}
