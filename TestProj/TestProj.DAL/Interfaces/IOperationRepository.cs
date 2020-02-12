using System.Linq;
using System.Threading.Tasks;
using TestProj.DAL.Entities;

namespace TestProj.DAL.Interfaces
{
    public interface IOperationRepository
    {
        IQueryable<Operation> GetOperations(int id);
        Task<Operation> Create(Operation item);
    }
}
