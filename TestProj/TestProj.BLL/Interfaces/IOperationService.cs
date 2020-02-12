using System.Collections.Generic;
using System.Threading.Tasks;
using TestProj.BLL.Models;


namespace TestProj.BLL.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAllOperations(int id);
        Task<OperationDTO> AddOperation(OperationDTO model);
    }
}