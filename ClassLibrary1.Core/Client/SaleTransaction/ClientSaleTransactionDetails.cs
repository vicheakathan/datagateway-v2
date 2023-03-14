using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientSaleTransactionDetails
    {
        public DateTime CreateDate { get; set; }

        public string? Type { get; set; }

        public string? Key { get; set; }

        public string? Description { get; set; }

        public decimal Percentage { get; set; }

        public decimal Amount { get; set; }

        public string? ReasonCode { get; set; }

        public string? ReasonCodeName { get; set; }

        public string? PromotionName { get; set; }

        public string? PromotionCode { get; set; }

        public string? CreateByName { get; set; }

        public string? CreateById { get; set; }

        public Guid CreateByTerminalId { get; set; }

        public string? CreateByTerminalName { get; set; }

        public string? Note { get; set; }

        public Guid SaleTransactionId { get; set; }

        public ClientSaleTransactionDetails() { }
    }
}
