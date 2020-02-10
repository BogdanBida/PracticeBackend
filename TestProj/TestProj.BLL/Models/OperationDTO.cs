using System;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Models
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public OperationType OperationType { get; set; }
        public string AppUserId { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
