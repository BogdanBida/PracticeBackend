using System.Collections.Generic;
using System.Linq;
using TestProj.BLL.Models;


namespace TestProj.BLL.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAllOperations(int id);
        OperationDTO AddOperation(OperationDTO model);
    }
}