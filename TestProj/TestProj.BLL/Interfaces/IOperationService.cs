using System.Collections.Generic;
using TestProj.BLL.Models;


namespace TestProj.BLL.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAllOperations();
        OperationDTO AddOperation(OperationDTO model);
    }
}