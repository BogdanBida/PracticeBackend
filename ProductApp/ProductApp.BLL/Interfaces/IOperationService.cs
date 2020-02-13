using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.BLL.Models;


namespace ProductApp.BLL.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAllOperations(int id);
        Task AddOperation(OperationDTO model);
    }
}