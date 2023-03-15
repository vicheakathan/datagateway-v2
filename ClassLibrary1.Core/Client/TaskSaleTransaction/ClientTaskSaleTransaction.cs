using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientTaskSaleTransaction
    {
        public Guid SaleTransactionId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public DateTime? FailDate { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsFail { get; set; }

        public string? Tenant { get; set; }

        public ClientTaskSaleTransaction() { }
    }
}
