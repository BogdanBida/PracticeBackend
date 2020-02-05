using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProj.Models
{
    public class OperationsModel
    {
        public Guid OperationId { get; set; }
        public ProductModel Product { get; set; }
        public AppUser User { get; set; }
        public int Count { get; set; }
        public Operation Operation { get; set; }
    }
}
